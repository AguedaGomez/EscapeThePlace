using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NearbyMessages
{
    [Serializable]
    public class NearbyMessage
    {
        public string Content { get; }
        public string Namespace { get; }
        public string Type { get; }
        public int DistanceAccuracy { get; private set; }
        public int SignalRssi { get; private set; }
        public int SignalTx { get; private set; }
        public double DistanceMeters { get; private set; }
        public string Id { get => $"{Type}/{Content}"; }

        public NearbyMessage(string content, string nspace, string type)
        {
            Content = content;
            Namespace = nspace;
            Type = type;
        }

        public NearbyMessage(NearbyVirtualDevice device): this(device.message, device.deviceNamespace, device.deviceType) { }

        public NearbyMessage UpdateDistance(double distance, int accuracy)
        {
            DistanceMeters = distance;
            DistanceAccuracy = accuracy;
            return this;
        }

        public NearbyMessage UpdateSignal(int rssi, int txPower)
        {
            SignalRssi = rssi;
            SignalTx = txPower;
            return this;
        }
    }
}