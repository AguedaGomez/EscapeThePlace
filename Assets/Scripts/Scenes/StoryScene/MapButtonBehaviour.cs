using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButtonBehaviour : MonoBehaviour
{
    public Sprite targetImage;
    public Sprite pressedImage;
    public Image buttonImage;

    private MapPuzzleManager mapPuzzleManager;

    void Start()
    {
        mapPuzzleManager = transform.parent.GetComponent<MapPuzzleManager>(); 
    }

    public void OnButtonClick()
    {
        Button myButton = GetComponent<Button>();

        if (buttonImage.sprite == pressedImage)
        {
            buttonImage.sprite = targetImage;
            mapPuzzleManager.currentList.Remove(myButton);
        }
            
        else
        {
            buttonImage.sprite = pressedImage;
            mapPuzzleManager.currentList.Add(myButton);
        }
        mapPuzzleManager.CheckSequence();
            
    }

}
