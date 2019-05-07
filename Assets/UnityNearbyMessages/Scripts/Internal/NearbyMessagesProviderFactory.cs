using System;

namespace NearbyMessages.Internal
{
    public class NearbyMessagesProviderFactory
    {
        public static INearbyMessagesProvider CreateProvider(NearbyMessagesProviderConfig config)
        {
#if UNITY_EDITOR
            return VirtualNearbyMessagesProvider.Instance;
#elif UNITY_ANDROID
            return new AndroidNearbyMessagesProvider();
#elif UNITY_IOS
            return new IOSNearbyMessagesProvider(config.iOSApiKey);
#else
            throw new InvalidOperationException("There is no nearby provider implementation for your platform");
#endif
        }
    }

    [Serializable]
    public class NearbyMessagesProviderConfig
    {
        public string androidApiKey;
        public string iOSApiKey;
    }
}

