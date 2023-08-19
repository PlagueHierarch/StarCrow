using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerbook : MonoBehaviour
{
    public GameObject answerBook;
    public CanvasGroup answerBookGroup;
    public AudioSource AudioSource;
    public bool answerBookOn = false;
    private void OnMouseDown()
    {
        if(SettingPageManager.GamePaused == false && BookSwitch.BookOn == false)
        {
            BookSwitch.BookOn = true;
            answerBookGroup.alpha = 1;
            answerBookOn = true;
            answerBook.SetActive(true);
        }
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && answerBookOn == true)
        {
            AudioSource.Play();
            answerBook.SetActive(false);
            answerBookOn = false;
            BookSwitch.BookOn = false;
        }
    }
}
