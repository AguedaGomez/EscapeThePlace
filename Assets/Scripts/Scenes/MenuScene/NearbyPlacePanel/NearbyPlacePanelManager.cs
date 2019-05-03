using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NearbyMessages;

public class NearbyPlacePanelManager : PanelManager
{
    public Text text;

    private NearbyMessagesEventSystem _nearbyMessages;
    private Dictionary<string, string> _placeLabels;
    private string _currentPlace;

    public void Show(string placeName)
    {
        Init();
        _nearbyMessages.OnNearbyMessageLost += OnSceneOutOfRange;
        DisplayPlace(placeName);
        base.Show();
    }

    public override void Hide()
    {
        _nearbyMessages.OnNearbyMessageLost -= OnSceneOutOfRange;
        base.Hide();
    }

    private void OnSceneOutOfRange(NearbyMessage message)
    {
        if (message.Content != _currentPlace) return;
        Hide();
    }

    private void Init()
    {
        if (_placeLabels != null) return;
        _nearbyMessages = NearbyMessagesEventSystem.Instance;
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
