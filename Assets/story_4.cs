using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class story_4 : MonoBehaviour
{
    public AudioSource audio;
    public CanvasGroup BlackScreen;
    public CanvasGroup text;
    void Start()
    {
        StartCoroutine(ScenePlay());
    }

    IEnumerator ScenePlay()
    {
        yield return new WaitForSeconds(2);
        while (BlackScreen.alpha > 0.0f)
        {
            BlackScreen.alpha -= Time.deltaTime;
            text.alpha -= Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        audio.Play();
        yield return null;
    }
}
