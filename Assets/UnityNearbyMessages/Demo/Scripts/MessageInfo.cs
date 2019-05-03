using UnityEngine;
using UnityEngine.UI;

namespace NearbyMessages.Demo
{
    public class MessageInfo : MonoBehaviour
    {
        public Text msgContent,
            msgNamespace, msgType,
            msgDistance, msgSignal;

        public void SetNearbyMessage(NearbyMessage message)
        {
            DisplayMsgContent(message.Content);
            DisplayMsgNamespace(message.Namespace);
            DisplayMsgType(message.Type);
            DisplayMsgDistance(message.DistanceMeters, message.DistanceAccuracy);
            DisplayMsgSignal(message.SignalRssi, message.SignalTx);
        }

        private void DisplayMsgContent(string content)
        {
            msgContent.text = $"Message: {content}";
        }

        private void DisplayMsgNamespace(string nspace)
        {
            msgNamespace.text = $"Namespace: {nspace}";
        }

        private void DisplayMsgType(string type)
        {
            msgType.text = $"Type: {type}";
        }

        private void DisplayMsgDistance(double distance, int accuracy)
        {
            msgDistance.text = $"Distance: {distance:F2}m ({accuracy}%)";
        }

        private void DisplayMsgSignal(int rssi, int txPower)
        {
            msgSignal.text = $"Rx: {rssi} dBm | Tx: {txPower} dBm";
        }
    }
}