using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterActivator : ScreenPhase
{
    public float speed = 0.05f;
    public Text textBox;

    private string currentText = "";
    private string fullText;
    private Coroutine effect;

    public override void InitPhase()
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
        NotifyPhaseFinished();
    }

    public void CancelEffect()
    {
        StopCoroutine(effect);
        textBox.text = fullText;
        NotifyPhaseFinished();

    }
}
