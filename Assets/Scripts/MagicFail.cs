using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicFail : MonoBehaviour
{

    public float flashSpeed = 5f;
    public CanvasGroup flashimage;
    public CanvasGroup answerBookGroup;
    public GameObject answerBook;
    public answerbook answerbook;

    public AudioSource audioSource;
    public void Failed()
    {
        audioSource.Play();
        StartCoroutine(Flashscreen());
        answerBookGroup.alpha = 0;
        answerbook.answerBookOn = false;
        BookSwitch.BookOn = false;
    }
    public IEnumerator Flashscreen()
    {       
        while(flashimage.alpha < 1)
        {
            flashimage.alpha += Time.deltaTime * flashSpeed;
            yield return null;
        }
        while(flashimage.alpha > 0)
        {
            flashimage.alpha -= Time.deltaTime * flashSpeed;
            yield return null;
        }
        
    }
}
