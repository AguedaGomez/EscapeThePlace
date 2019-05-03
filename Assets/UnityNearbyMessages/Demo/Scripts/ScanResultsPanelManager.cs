using System.Collections.Generic;
using UnityEngine;
using NearbyMessages;
using NearbyMessages.Demo;

public class ScanResultsPanelManager : MonoBehaviour
{

    public GameObject scanResultsPanel;
    public GameObject nearbyMessagesContainer;
    public GameObject nearbyMessagePrefab;

    private NearbyMessagesEventSystem _nearbyMessages;
    public Dictionary<string, GameObject> _nearbyMessagesPrefabs = new Dictionary<string, GameObject>();

    public void Show()
    {
        _nearbyMessages = NearbyMessagesEventSystem.Instance;
        _nearbyMessages.OnNearbyMessageFound += RenderNearbyMessage;
        _nearbyMessages.OnNearbyMessageChanged += UpdateNearbyMessage;
        _nearbyMessages.OnNearbyMessageLost += RemoveNearbyMessage;
        DisplayNearbyMessages(_nearbyMessages.Messages);
        scanResultsPanel.SetActive(true);
    }

    public void Hide()
    {
        scanResultsPanel.SetActive(false);
        _nearbyMessages.OnNearbyMessageFound -= RenderNearbyMessage;
        _nearbyMessages.OnNearbyMessageChanged -= UpdateNearbyMessage;
        _nearbyMessages.OnNearbyMessageLost -= RemoveNearbyMessage;
    }

    private void DisplayNearbyMessages(List<NearbyMessage> nearbyMessages)
    {
        ClearNearbyMessages();
        foreach (var nearbyMessage in nearbyMessages)
        {
            RenderNearbyMessage(nearbyMessage);
        }
    }

    private void RenderNearbyMessage(NearbyMessage message)
    {
        var prefabInstance = Instantiate(nearbyMessagePrefab, nearbyMessagesContainer.transform);
        _nearbyMessagesPrefabs.Add(message.Id, prefabInstance);

        UpdateNearbyMessage(message);
    }

    private void UpdateNearbyMessage(NearbyMessage message)
    {
        var nearbyMessageObject = _nearbyMessagesPrefabs[message.Id];
        nearbyMessageObject.GetComponent<MessageInfo>().SetNearbyMessage(message);
    }

    private void RemoveNearbyMessage(NearbyMessage message)
    {
        var nearbyMessageObject = _nearbyMessagesPrefabs[message.Id];
        Destroy(nearbyMessageObject);
        _nearbyMessagesPrefabs.Remove(message.Id);
    }

    private void ClearNearbyMessages()
    {
        foreach (var entry in _nearbyMessagesPrefabs)
        {
            Destroy(entry.Value);
        }
        _nearbyMessagesPrefabs.Clear();
    }
}
