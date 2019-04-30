using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumericPanelBehaviour : MonoBehaviour
{
    public Text screenText;
    public string correctCode;
    public int lenghtCode;

    // Start is called before the first frame update
    void Start()
    {
        
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
            print("códicoCorrecto");
        else
        {
            print("códigoIncorrecto");
            ClearCode();
        }
    }
}
