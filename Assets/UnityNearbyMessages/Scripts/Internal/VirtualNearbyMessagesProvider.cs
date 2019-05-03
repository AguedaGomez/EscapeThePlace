using System;
using System.Collections.Generic;

namespace NearbyMessages.Internal
{
    public class VirtualNearbyMessagesProvider : INearbyMessagesProvider
    {
        public static VirtualNearbyMessagesProvider Instance { get; } = new VirtualNearbyMessagesProvider();

        public event Action<string> OnMessageFound;
        public event Action<string> OnDistanceChanged;
        public event Action<string> OnSignalChanged;
        public event Action<string> OnMessageLost;

        private Dictionary<string, NearbyMessage> _nearbyMessages = new Dictionary<string, NearbyMessage>();
        private bool _scanRunning;
        private Random _random = new Random();


        private VirtualNearbyMessagesProvider() { }

        public void StartScan()
        {
            if (_scanRunning) return;
            _scanRunning = true;
            
            foreach (var entry in _nearbyMessages)
            {
                NotifyMessageFound(entry.Value);
            }
        }

        public void StopScan()
        {
            if (!_scanRunning) return;
            _scanRunning = false;
        }

        internal void NearbyDeviceAdded(NearbyVirtualDevice device)
        {
            var message = new NearbyMessage(device);
            _nearbyMessages[message.Id] = message;
            NotifyMessageFound(message);
        }

        internal void NearbyMessageRemoved(NearbyVirtualDevice device)
        {
            var message = _nearbyMessages[device.Id];
            _nearbyMessages.Remove(message.Id);
            NotifyMessageLost(message);
        }

        internal void SimulateNearbyDeviceChanges()
        {
            foreach (var entry in _nearbyMessages)
            {
                MutateDevice(entry.Value);
            }
        }

        private void MutateDevice(NearbyMessage message)
        {
            message.UpdateDistance(_random.NextDouble() * 500, _random.Next(1,100));
            message.UpdateSignal(_random.Next(-127, 127), _random.Next(-127, 127));

            NotifyDistanceChanged(message);
            NotifySignalChanged(message);
        }

        private void NotifyMessageFound(NearbyMessage message)
        {
            var encodedMessage = $"{message.Content}<[]>{message.Namespace}<[]>{message.Type}";
            Notify(OnMessageFound, encodedMessage);
        }

        private void NotifyDistanceChanged(NearbyMessage message)
        {
            var encodedMessage = $"{message.Content}<[]>{message.Namespace}<[]>{message.Type}<[]>{message.DistanceMeters}<[]>{message.DistanceAccuracy}";
            Notify(OnDistanceChanged, encodedMessage);
        }

        private void NotifySignalChanged(NearbyMessage message)
        {
            var encodedMessage = $"{message.Content}<[]>{message.Namespace}<[]>{message.Type}<[]>{message.SignalRssi}<[]>{message.SignalTx}";
            Notify(OnSignalChanged, encodedMessage);
        }

        private void NotifyMessageLost(NearbyMessage message)
        {
            var encodedMessage = $"{message.Content}<[]>{message.Namespace}<[]>{message.Type}";
            Notify(OnMessageLost, encodedMessage);
        }

        private void Notify(Action<string> action, string encodedMessage)
        {
            if (!_scanRunning) return;
            action?.Invoke(encodedMessage);
        }
    }
}

