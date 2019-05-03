using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearbyMessages;

public class SearchPanelManager : PanelManager
{
    public NearbyMessagesEventSystem nearbyMessages;
    public NearbyPlacePanelManager nearbyPlacePanel;
    public PanelManager nearbyPlaceNotFoundPanel;
    public int searchTimeout;

    private Coroutine _timeout;

    public override void Show()
    {
        nearbyMessages.OnNearbyMessageFound += OnPlaceNearby;
        base.Show();
        _timeout = StartCoroutine(SearchTimeout());
    }

    public override void Hide()
    {
        nearbyMessages.OnNearbyMessageFound -= OnPlaceNearby;
        CancelTimeout();
        base.Hide();
    }

    private IEnumerator SearchTimeout()
    {
        yield return new WaitForSeconds(searchTimeout);
        _timeout = null;
        Hide();
        nearbyPlaceNotFoundPanel.Show();
    }

    private void OnPlaceNearby(NearbyMessage message)
    {
        Hide();
        nearbyPlacePanel.Show(message.Content);
    }

    private void CancelTimeout()
    {
        if (_timeout == null) return;
        StopCoroutine(_timeout);
        _timeout = null;
    }
}
