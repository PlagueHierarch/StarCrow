using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseClick : MonoBehaviour
{
    public GameObject dialogueManager;
    public GameObject dialoguepos;
    SpeechBubbleShow bubbleShow;
    AudioSource audioSource;
    public int clickCount;

    float continueTime = 1f;
    float clickTime = -2f;
    bool isClickContinued = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        bubbleShow = dialogueManager.GetComponent<SpeechBubbleShow>();
    }
    private void OnMouseDown()
    {
        if (clickCount >= 12)
        {
            if(SpeechBubbleShow.bubbleOn == false && BookSwitch.BookOn == false && SettingPageManager.GamePaused == false)
            {
                bubbleShow.dialoguepos = dialoguepos;
                bubbleShow.obj = 4;
                bubbleShow.scriptNo = 0;
                StartCoroutine(bubbleShow.Bubble());
            }
            
            
        }

        else
        {
            if((Time.time - clickTime) < continueTime)
            {
                clickTime = Time.time;
                isClickContinued = true;
            }
            else
            {
                clickCount = 0;
                isClickContinued = false;
                clickTime = Time.time;
            }
            
        }
        
    }

    private void Update()
    {
        if(isClickContinued == true)
        {
            audioSource.Play();
            clickCount++;
            Debug.Log("clickcount = " + clickCount);
            isClickContinued = false;
        }
    }
}
