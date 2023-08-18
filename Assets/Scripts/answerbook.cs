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
            answerBookGroup.alpha = 1;
        }
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            answerBookGroup.alpha = 0;
            BookSwitch.BookOn = false;
        }
    }
}
