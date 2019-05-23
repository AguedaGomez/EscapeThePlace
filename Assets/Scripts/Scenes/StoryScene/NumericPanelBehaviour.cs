using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumericPanelBehaviour : ScreenPhase
{
    public Text screenText;

    public int lenghtCode;
    public Image redLight;
    public Image greenLight;
    public Sprite redLightOff;
    public Sprite greenLightOff;
    public Sprite redLightOn;
    public Sprite greenLightOn;

    private string correctCode;

    void Start()
    {
        correctCode = GameState.Instance.PuzzleAnswers.GetDoorCode();
    }
    public void OnNumericButtonClick(Text value)
   {
        if (value.text == "C")
            ClearCode();
        else if (value.text == "OK")
            CheckCode();
        else if(screenText.text.Length < lenghtCode)
            screenText.text += value.text;
   }

    private void ClearCode()
    {
        screenText.text = "";
    }

    private void CheckCode()
    {
        if (screenText.text == correctCode)
            StartCoroutine(TurnGreenLightOn());
        else
        {
            StartCoroutine(TurnRedLightOn());
            ClearCode();
        }
    }
    IEnumerator TurnRedLightOn()
    {
        
        yield return TurnLightOn(redLight, redLightOn, redLightOff);
        
    }

    IEnumerator TurnGreenLightOn()
    {
        yield return TurnLightOn(greenLight, greenLightOn, greenLightOff);
        NotifyPhaseFinished();
    }
    IEnumerator TurnLightOn(Image lightImage, Sprite lightOnSprite, Sprite lightOffSprite)
    {
        lightImage.sprite = lightOnSprite;
        lightImage.SetNativeSize();
        yield return new WaitForSeconds(1);
        lightImage.sprite = null;
        lightImage.sprite = lightOffSprite;
        lightImage.SetNativeSize();
    }
}
