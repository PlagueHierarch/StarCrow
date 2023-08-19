using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerbook : MonoBehaviour
{
    public GameObject answerBook;
    public CanvasGroup answerBookGroup;
    public GameObject SubmitBtn;
    public GameObject SubmitField;

    private void Start()
    {
        SubmitBtn.SetActive(false);
        SubmitField.SetActive(false);
    }

    private void OnMouseDown()
    {
        if(SettingPageManager.GamePaused == false && BookSwitch.BookOn == false)
        {
            BookSwitch.BookOn = true;
            answerBookGroup.alpha = 1;
            SubmitBtn.SetActive (true);
            SubmitField.SetActive (true);
        }
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            answerBookGroup.alpha = 0;
            BookSwitch.BookOn = false;
            SubmitBtn.SetActive(false);
            SubmitField.SetActive(false);
        }
    }
}
