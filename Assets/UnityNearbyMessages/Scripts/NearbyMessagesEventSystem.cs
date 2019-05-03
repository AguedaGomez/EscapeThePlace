using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearbyMessages.Internal;

namespace NearbyMessages
{
    public class NearbyMessagesEventSystem : MonoBehaviour
    {
        public int messageLostTimeout;

        public static NearbyMessagesEventSystem Instance { get; private set; }

        public event Action<NearbyMessage> OnNearbyMessageFound
        {
            add => AddEventListener(Event.Found, value);
            remove => RemoveEventListener(Event.Found, value);
        }
        public event Action<NearbyMessage> OnNearbyMessageChanged
        {
            add => AddEventListener(Event.Changed, value);
            remove => RemoveEventListener(Event.Changed, value);
        }
        public event Action<NearbyMessage> OnNearbyMessageLost
        {
            add => AddEventListener(Event.Lost, value);
            remove => RemoveEventListener(Event.Lost, value);
        }
        public event Action<string> OnError;

        public List<NearbyMessage> Messages { get => new List<NearbyMessage>(_nearbyMessages.Values); }

        private INearbyMessagesProvider _messagesProvider;
        private MessageParser _messageParser;

        private Dictionary<string, NearbyMessage> _nearbyMessages = new Dictionary<string, NearbyMessage>();
        private Dictionary<string, Coroutine> _lostTimeOuts = new Dictionary<string, Coroutine>();
        private bool _scanRunning;

        private event Action<NearbyMessage> _onNearbyMessageFound, _onNearbyMessageChanged, _onNearbyMessageLost;
        private int _listenersCounter;

        void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Initialize();
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void MessageFound(string encodedMessage)
        {
            var message = _messageParser.Parse(encodedMessage);
            _nearbyMessages[message.Id] = message;
            if (!_lostTimeOuts.ContainsKey(message.Id))
            {
                Notify(_onNearbyMessageFound, message);
                return;
            }
            CancelTimeoutFor(message);
        }

        public void MessageDistanceChanged(string encodedMessage)
        {
            var message = _messageParser.ParseWithDistance(encodedMessage);
            if (!_nearbyMessages.ContainsKey(message.Id)) return;

            var updatedMessage = _nearbyMessages[message.Id]
                .UpdateDistance(message.DistanceMeters, message.DistanceAccuracy);
            _nearbyMessages[message.Id] = updatedMessage;
            Notify(_onNearbyMessageChanged, updatedMessage);
        }

        public void MessageSignalChanged(string encodedMessage)
        {
            var message = _messageParser.ParseWithSignal(encodedMessage);
            if (!_nearbyMessages.ContainsKey(message.Id)) return;

            var updatedMessage = _nearbyMessages[message.Id]
                .UpdateSignal(message.SignalRssi, message.SignalTx);
            _nearbyMessages[message.Id] = updatedMessage;
            Notify(_onNearbyMessageChanged, updatedMessage);
        }

        public void MessageLost(string encodedMessage)
        {
            var message = _messageParser.Parse(encodedMessage);
            if (!_nearbyMessages.ContainsKey(message.Id)) return;

            var oldMessage = _nearbyMessages[message.Id];
            _lostTimeOuts[message.Id] = StartCoroutine(LostTimeout(oldMessage));
        }

        public void ProviderFailure(string error)
        {
            OnError?.Invoke(error);
        }

        #region private
        private void Initialize()
        {
            Instance = this;
            _messagesProvider = NearbyMessagesProviderFactory.CreateProvider();
            _messageParser = new MessageParser();
        }

        private void AddEventListener(Event evt, Action<NearbyMessage> listener)
        {
            lock (this)
            {
                if (_listenersCounter == 0)
                {
                    StartScan();
                }
                _listenersCounter++;

                switch (evt)
                {
                    case Event.Found:
                        _onNearbyMessageFound += listener;
                        break;
                    case Event.Changed:
                        _onNearbyMessageChanged += listener;
                        break;
                    case Event.Lost:
                        _onNearbyMessageLost += listener;
                        break;
                }
            }
        }

        private void RemoveEventListener(Event evt, Action<NearbyMessage> listener)
        {
            lock (this)
            {
                if (_listenersCounter == 1)
                {
                    StopScan();
                }
                _listenersCounter--;

                switch (evt)
                {
                    case Event.Found:
                        _onNearbyMessageFound -= listener;
                        break;
                    case Event.Changed:
                        _onNearbyMessageChanged -= listener;
                        break;
                    case Event.Lost:
                        _onNearbyMessageLost -= listener;
                        break;
                }
            }
        }

        private void StartScan()
        {
            if (_scanRunning) return;
            _scanRunning = true;
            _nearbyMessages.Clear();
            _messagesProvider.StartScan();
        }

        private void StopScan()
        {
            if (!_scanRunning) return;
            _scanRunning = false;
            _messagesProvider.StopScan();
        }

        private void Notify(Action<NearbyMessage> action, NearbyMessage message)
        {
            action?.Invoke(message);
        }

        private IEnumerator LostTimeout(NearbyMessage message)
        {
            yield return new WaitForSeconds(messageLostTimeout);
            _lostTimeOuts.Remove(message.Id);
            _nearbyMessages.Remove(message.Id);
            Notify(_onNearbyMessageLost, message);
        }

        private void CancelTimeoutFor(NearbyMessage message)
        {
            var lostTimeout = _lostTimeOuts[message.Id];
            StopCoroutine(lostTimeout);
            _lostTimeOuts.Remove(message.Id);
        }

        private enum Event
        {
            Found, Changed, Lost
        }
        #endregion
    }
}
