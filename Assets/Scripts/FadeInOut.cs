using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fadeinout : MonoBehaviour
{
    public CanvasGroup canvasgroup;
    public float fadeouttime;
    public float fadeintime;

    public bool fadein;

    private void Start()
    {
        canvasgroup.alpha = 1.0f;
        fadein = false;
    }

    private void Update()
    {
        //씬 전환 후 페이드인
        if (fadein == false)
        {
            //Debug.Log("Fadein" + fadein);
            StartCoroutine(Fading());
        }
    }

    public IEnumerator Fadeout()
    { 

        while (canvasgroup.alpha < 1)
        {
            canvasgroup.alpha += Time.deltaTime / fadeouttime;
            yield return null;
        }

    }

    public IEnumerator Fadein()
    {
        while (canvasgroup.alpha > 0)
        {
            canvasgroup.alpha -= Time.deltaTime * fadeintime;
            //Debug.Log("fadeinalpha : "+canvasgroup.alpha);
            yield return null;
        }
        fadein = true;
    }

    public IEnumerator Fading()
    {
            yield return StartCoroutine(Fadein());
    }
}
