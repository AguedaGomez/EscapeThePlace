using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWritterEffect : MonoBehaviour
{
    public float speed = 0.1f;    
    public Text textBox;
    public delegate void TypeWritter();
    public event TypeWritter EffectIsFinish;

    private string currentText = "";
    private string fullText;
    private Coroutine effect;

    void Start()
    {
        fullText = textBox.text;
        textBox.text = "";
        effect = StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textBox.text = currentText;
            yield return new WaitForSeconds(speed);
            
        }
        EffectIsFinish();
    }

    public void CancelEffect()
    {
        StopCoroutine(effect);
        textBox.text = fullText;
        EffectIsFinish();
         
    }
}
