using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FPSdisplay : MonoBehaviour
{

    public float timer, refresh, avgFrameRate;
    public float display;
    public TMP_Text m_Text;

    private void Update()
    {
        float timeLapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timeLapse;

        if(timer <= 0) avgFrameRate = (int) (1f / timeLapse);
        m_Text.text = avgFrameRate + " FPS";
    }


}
