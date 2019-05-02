using UnityEngine;
using UnityEngine.Android;

namespace NearbyMessages.Internal
{
    public class AndroidNearbyMessagesProvider : INearbyMessagesProvider
    {

        private AndroidJavaObject _nearbyMessages;

        public AndroidNearbyMessagesProvider()
        {
            Init();
        }

        public void StartScan()
        {
            Init();
            _nearbyMessages?.Call("startScan");
        }

        public void StopScan()
        {
            _nearbyMessages?.Call("stopScan");
        }

        private void Init()
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                Permission.RequestUserPermission(Permission.FineLocation);
                return;
            }
            if (_nearbyMessages != null) return;
            _nearbyMessages = new AndroidJavaObject("es.agonper.unitynearbymessages.NearbyMessages");
        }
    }
}

