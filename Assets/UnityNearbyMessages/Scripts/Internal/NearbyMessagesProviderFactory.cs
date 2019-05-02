using System;

namespace NearbyMessages.Internal
{
    public class NearbyMessagesProviderFactory
    {
        public static INearbyMessagesProvider CreateProvider()
        {
#if UNITY_EDITOR
            return VirtualNearbyMessagesProvider.Instance;
#elif UNITY_ANDROID
            return new AndroidNearbyMessagesProvider();
#else
            throw new InvalidOperationException("There is no nearby provider implementation for your platform");
#endif
        }
    }
}

