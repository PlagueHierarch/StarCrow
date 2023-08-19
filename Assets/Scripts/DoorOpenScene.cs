using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DoorOpenScene : MonoBehaviour
{
    public GameObject Story1;
    public GameObject Story2;
    public GameObject Story3;
    public GameObject Story4;
    public VideoPlayer vid;

    public Fadeinout fadeinout;

    bool startcoroutine = false;
    private void Awake()
    {
        Story1.SetActive(true);
        Story2.SetActive(false);
        Story3.SetActive(false);
        Story4.SetActive(false);
    }

    private void Update()
    {
        if (fadeinout.fadein == true && startcoroutine == false)
        {
            startcoroutine = true;
            StartCoroutine(SceneDoorOpen());
        }
    }

    IEnumerator SceneDoorOpen()
    {
        fadeinout.fadeintime = 2f;
        yield return new WaitForSeconds(3);
        yield return StartCoroutine(fadeinout.Fadeout());
        Story1.SetActive(false);
        Story2.SetActive(true);
        yield return StartCoroutine(fadeinout.Fading());
        yield return new WaitForSeconds(3);
        yield return StartCoroutine(fadeinout.Fadeout());
        Story2.SetActive(false);
        Story3.SetActive(true);
        yield return StartCoroutine(fadeinout.Fading());
        yield return new WaitForSeconds(3);
        yield return StartCoroutine(fadeinout.Fadeout());
        Story3.SetActive(false);
        Story4.SetActive(true);
        yield return StartCoroutine(fadeinout.Fading());
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(fadeinout.Fadeout());
        Story4.SetActive(false);
        vid.Play();
        StartCoroutine(fadeinout.Fading());
        yield return new WaitForSeconds(1);
        
        yield return null;
        gameObject.SetActive(false);
    }
}
