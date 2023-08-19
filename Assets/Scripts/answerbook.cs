using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerbook : MonoBehaviour
{
    public GameObject answerBook;
    public CanvasGroup answerBookGroup;
    private void OnMouseDown()
    {
        if(SettingPageManager.GamePaused == false && BookSwitch.BookOn == false)
        {
            BookSwitch.BookOn = true;
            answerBookOn = true;
            answerBook.setActive(true);
        }
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && answerBookOn == true)
        {
            AudioSource.Play();
            answerBook.setActive(false);
            answerBookOn = false;
            BookSwitch.BookOn = false;
        }
    }
}
