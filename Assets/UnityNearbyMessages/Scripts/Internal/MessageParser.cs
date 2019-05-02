using System;

namespace NearbyMessages.Internal
{
    public class MessageParser
    {
        public NearbyMessage Parse(string encodedMsg)
        {
            var msgParts = ExtractMessageParts(encodedMsg);
            return MessageFromParts(msgParts);
        }

        public NearbyMessage ParseWithDistance(string encodedMsg)
        {
            var msgParts = ExtractMessageParts(encodedMsg);
            var message = MessageFromParts(msgParts);

            var meters = double.Parse(msgParts[3]);
            var accuracy = int.Parse(msgParts[4]);
            return message.UpdateDistance(meters, accuracy);
        }

        public NearbyMessage ParseWithSignal(string encodedMsg)
        {
            var msgParts = ExtractMessageParts(encodedMsg);
            var message = MessageFromParts(msgParts);

            var rx = int.Parse(msgParts[3]);
            var tx = int.Parse(msgParts[4]);
            return message.UpdateSignal(rx, tx);
        }

        private string[] ExtractMessageParts(string encodedMsg)
        {
            return encodedMsg.Split(new[] { "<[]>" }, StringSplitOptions.None);
        }

        private NearbyMessage MessageFromParts(string[] msgParts)
        {
            return new NearbyMessage(msgParts[0], msgParts[1], msgParts[2]);
        }
    }
}


