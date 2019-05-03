using System;

namespace NearbyMessages
{
    [Serializable]
    public class NearbyVirtualDevice
    {
        public string message, deviceNamespace, deviceType;

        public string Id { get => new NearbyMessage(this).Id; }
    }
}

