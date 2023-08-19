using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatClick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    public Sprite cat1;
    public Sprite cat2;
    public AudioClip cathiss;

    public GameObject dialogueManager;
    public NoiseManagement noiseManager;
    public GameObject dialoguepos;
    public GameObject dialoguepos2;
    SpeechBubbleShow speechbubble;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        speechbubble = dialogueManager.GetComponent<SpeechBubbleShow>();
        
        speechbubble.scriptNo = 0;
    }
    public void OnMouseDown()
    {
        speechbubble.obj = 1;

        if (speechbubble.scriptNo > 0)
        {
            speechbubble.dialoguepos = dialoguepos;
        }

        else
        {
            speechbubble.dialoguepos = dialoguepos2;
        }

        if(SpeechBubbleShow.bubbleOn == false && SettingPageManager.GamePaused == false && BookSwitch.BookOn == false)
        {
            StartCoroutine(changesprite());
        }

    }

    private IEnumerator changesprite()
    {
        SpeechBubbleShow.bubbleOn = true;
        speechbubble.scriptNo = noiseManager.Noise - 1;
        audioSource.clip = cathiss;
        audioSource.Play();
        if (speechbubble.scriptNo == 0)
        {
            spriteRenderer.sprite = cat2;
        }        
        StartCoroutine(speechbubble.Bubble());
        yield return new WaitForSeconds(2);
        spriteRenderer.sprite = cat1;
    }
}
