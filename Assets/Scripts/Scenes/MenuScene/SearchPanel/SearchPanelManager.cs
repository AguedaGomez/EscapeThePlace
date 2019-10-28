using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using IBeacons;

public class SearchPanelManager : PanelManager
{
//    public NearbyPlacePanelManager nearbyPlacePanel;
    public PanelManager nearbyPlaceNotFoundPanel;
    public string sceneToLoad;
    public int searchTimeout;

    private IBeaconsEventSystem _nearbyMessages;
    private Coroutine _timeout;

    public override void Show()
    {
        _nearbyMessages = IBeaconsEventSystem.Instance;
        _nearbyMessages.OnBeaconFound += OnPlaceNearby;
        base.Show();
        _timeout = StartCoroutine(SearchTimeout());
    }

    public override void Hide()
    {
        _nearbyMessages.OnBeaconFound -= OnPlaceNearby;
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

    private void OnPlaceNearby(IBeacon beacon)
    {
        Hide();
        GameState.Instance.currentPlace = beacon.Tag;
        SceneManager.LoadScene(sceneToLoad);
    }

    private void CancelTimeout()
    {
        if (_timeout == null) return;
        StopCoroutine(_timeout);
        _timeout = null;
    }
}
