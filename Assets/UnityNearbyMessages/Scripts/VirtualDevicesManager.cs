using System.Collections.Generic;
using UnityEngine;
using NearbyMessages;
using NearbyMessages.Internal;

public class VirtualDevicesManager : MonoBehaviour
{
    private static readonly float TIME_BETWEEN_DEVICE_CHANGES = 1.0f;

    public NearbyMessagesEventSystem nearbyMessages;
    public GameObject virtualDevicesContainer;
    public GameObject virtualDevicePrefab;
    public List<NearbyVirtualDevice> possibleNearbyDevices = new List<NearbyVirtualDevice>();

    private VirtualNearbyMessagesProvider _virtualNearbyProvider;

    private float timeUntilNextDeviceUpdate;

    void Start()
    {
        _virtualNearbyProvider = VirtualNearbyMessagesProvider.Instance;
        _virtualNearbyProvider.OnMessageFound += OnProviderMessageFound;
        _virtualNearbyProvider.OnDistanceChanged += OnProviderDistanceChanged;
        _virtualNearbyProvider.OnSignalChanged += OnProviderSignalChanged;
        _virtualNearbyProvider.OnMessageLost += OnProviderMessageLost;
        DisplayDevices();
    }

    void Update()
    {
        timeUntilNextDeviceUpdate -= Time.deltaTime;
        if (timeUntilNextDeviceUpdate > 0) return;

        timeUntilNextDeviceUpdate = TIME_BETWEEN_DEVICE_CHANGES;
        _virtualNearbyProvider.SimulateNearbyDeviceChanges();
    }

    private void OnProviderMessageFound(string encodedMessage)
    {
        nearbyMessages.MessageFound(encodedMessage);
    }

    private void OnProviderDistanceChanged(string encodedMessage)
    {
        nearbyMessages.MessageDistanceChanged(encodedMessage);
    }

    private void OnProviderSignalChanged(string encodedMessage)
    {
        nearbyMessages.MessageSignalChanged(encodedMessage);
    }

    private void OnProviderMessageLost(string encodedMessage)
    {
        nearbyMessages.MessageLost(encodedMessage);
    }

    private void DisplayDevices()
    {
        foreach (var device in possibleNearbyDevices)
        {
            DisplayDevice(device);
        }
    }

    private void DisplayDevice(NearbyVirtualDevice device)
    {
        var virtualDeviceItem = Instantiate(virtualDevicePrefab, virtualDevicesContainer.transform)
            .GetComponent<VirtualDeviceBehaviour>();
        virtualDeviceItem.SetVirtualDevice(device);
        virtualDeviceItem.SetOnToggleAction(OnDeviceToogle);
    }

    private void OnDeviceToogle(bool active, NearbyVirtualDevice device)
    {
        if (active)
        {
            _virtualNearbyProvider.NearbyDeviceAdded(device);
            return;
        }
        _virtualNearbyProvider.NearbyMessageRemoved(device);
    }
}
