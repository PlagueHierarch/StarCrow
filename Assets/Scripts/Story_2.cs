using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_2 : MonoBehaviour
{
    public GameObject dialog;
    public CanvasGroup ImageC;
    public CanvasGroup textC;
    private void Awake()
    {
        dialog.SetActive(false);
    }
    private void Start()
    {
        StartCoroutine(ScenePlay());
    }
    IEnumerator ScenePlay()
    {
        yield return new WaitForSeconds(2);
        while (ImageC.alpha > 0.0f)
        {
            ImageC.alpha -= Time.deltaTime;
            textC.alpha -= Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        dialog.SetActive(true);
        yield return null;
    }
}
