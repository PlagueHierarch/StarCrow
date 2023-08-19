using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerbook : MonoBehaviour
{
    public GameObject answerBook;
    public CanvasGroup answerBookGroup;
    public AudioSource AudioSource;
    bool answerBookOn = false;
    private void OnMouseDown()
    {
        if(SettingPageManager.GamePaused == false && BookSwitch.BookOn == false)
        {
            BookSwitch.BookOn = true;
            answerBookOn = true;
            answerBookGroup.alpha = 1;
        }
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && answerBookOn == true)
        {
            AudioSource.Play();
            answerBookGroup.alpha = 0;
            answerBookOn = false;
            BookSwitch.BookOn = false;
        }
    }
}
