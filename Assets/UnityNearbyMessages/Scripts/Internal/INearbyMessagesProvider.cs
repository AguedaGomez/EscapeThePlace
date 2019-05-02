using System;

namespace NearbyMessages.Internal
{
    public interface INearbyMessagesProvider
    {
        void StartScan();
        void StopScan();
    }
}

