using System;
using UnityEngine;
using UnityEngine.UI;

namespace NearbyMessages
{
    public class VirtualDeviceBehaviour : MonoBehaviour
    {
        public Text deviceId;
        public Toggle toggle;

        public NearbyVirtualDevice Device { get; private set; }

        public void SetVirtualDevice(NearbyVirtualDevice device)
        {
            Device = device;
            DisplayDeviceId(device.Id);
        }

        public void SetOnToggleAction(Action<bool, NearbyVirtualDevice> onToggle)
        {
            toggle.onValueChanged.AddListener((active) => onToggle(active, Device)); 
        }

        private void DisplayDeviceId(string id)
        {
            deviceId.text = id;
        }
    }
}
