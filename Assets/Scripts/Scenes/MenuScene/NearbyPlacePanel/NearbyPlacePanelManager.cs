using System.Collections.Generic;
using UnityEngine.UI;
using IBeacons;

public class NearbyPlacePanelManager : PanelManager
{
    public Text text;

    private IBeaconsEventSystem _iBeacons;
    private Dictionary<string, string> _placeLabels;
    private string _currentPlace;

    public void Show(string placeName)
    {
        Init();
        _iBeacons.OnBeaconLost += OnPlaceOutOfRange;
        DisplayPlace(placeName);
        base.Show();
    }

    public override void Hide()
    {
        _iBeacons.OnBeaconLost -= OnPlaceOutOfRange;
        base.Hide();
    }

    private void OnPlaceOutOfRange(IBeacon beacon)
    {
        if (beacon.Tag != _currentPlace) return;
        Hide();
    }

    private void Init()
    {
        if (_placeLabels != null) return;
        _iBeacons = IBeaconsEventSystem.Instance;
        _placeLabels = new Dictionary<string, string>
        {
            { "Kitchen", "la cocina" },
            { "Hall", "la entrada" },
            { "Basement", "los trasteros" }
        };
    }

    private void DisplayPlace(string placeName)
    {
        _currentPlace = placeName;
        text.text = $"¡Estás en {_placeLabels[placeName]}!".ToUpper();
    }


}
