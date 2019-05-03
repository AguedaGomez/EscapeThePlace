using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NearbyMessages;

public class SearchPanelManager : PanelManager
{
//    public NearbyPlacePanelManager nearbyPlacePanel;
    public PanelManager nearbyPlaceNotFoundPanel;
    public string sceneToLoad;
    public int searchTimeout;

    private NearbyMessagesEventSystem _nearbyMessages;
    private Coroutine _timeout;

    public override void Show()
    {
        _nearbyMessages = NearbyMessagesEventSystem.Instance;
        _nearbyMessages.OnNearbyMessageFound += OnPlaceNearby;
        base.Show();
        _timeout = StartCoroutine(SearchTimeout());
    }

    public override void Hide()
    {
        _nearbyMessages.OnNearbyMessageFound -= OnPlaceNearby;
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
        GameState.Instance.currentPlace = message.Content;
        SceneManager.LoadScene(sceneToLoad);
    }

    private void CancelTimeout()
    {
        if (_timeout == null) return;
        StopCoroutine(_timeout);
        _timeout = null;
    }
}
