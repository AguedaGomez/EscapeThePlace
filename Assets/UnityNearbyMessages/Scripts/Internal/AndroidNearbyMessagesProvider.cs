using UnityEngine;
using UnityEngine.Android;

namespace NearbyMessages.Internal
{
    public class AndroidNearbyMessagesProvider : INearbyMessagesProvider
    {

        private AndroidJavaObject _nearbyMessages;

        public AndroidNearbyMessagesProvider()
        {
            CheckPermissions();
            _nearbyMessages = new AndroidJavaObject("es.agonper.unitynearbymessages.NearbyMessages");
        }

        public void StartScan()
        {
            _nearbyMessages.Call("startScan");
        }

        public void StopScan()
        {
            _nearbyMessages.Call("stopScan");
        }

        private void CheckPermissions()
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation)) {
                Permission.RequestUserPermission(Permission.FineLocation);
            }
        }
    }
}

