using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoiseManagement : MonoBehaviour
{
    public GameObject Cat;
    public SceneMove GameOver_Cat;
    AudioSource audioSource_cat;
    public AudioClip[] ad;

    public AudioSource audioSource_crow;
    public float WaitingTime_Crow = 1.0f;

    public float WaitingTime_Cat = 4.0f;
    public TimerManager TimerManager;
    public CatClick catClick;
    public MagicFail magicFail;
    public GameObject answerbook;
    public answerbook AnswerBookScript;
    public PasswordManager passwordManager;
    public SpeechBubbleShow bubbleshow;
    public GameObject dialogueManager;

    private void Awake()
    {
        audioSource_cat = Cat.GetComponent<AudioSource>();
        audioSource_crow = GetComponent<AudioSource>();
    }

    private void Start()
    {
        bubbleshow = dialogueManager.GetComponent<SpeechBubbleShow>();
        //Cat.SetActive(false);
    }
    public int Noise = 0;
    
    public void AddNoise()
    {
        Noise++;
        PlayerPrefs.SetInt("catCounter", Noise);
        magicFail.Failed();
        if (Noise < 3) StartCoroutine(Warning());
        else StartCoroutine(GameOverCat());
    }

    public IEnumerator Warning()
    {
        catClick.spriteRenderer.sprite = catClick.cat2;
        bubbleshow.scriptNo = Noise - 1;
        audioSource_crow.Play();
        yield return new WaitForSeconds(WaitingTime_Crow);
        //Cat.SetActive(true);
        if (Noise <= 3) audioSource_cat.clip = ad[Random.Range(2, 5)];
        else audioSource_cat.clip = ad[Random.Range(0, 2)];
        audioSource_cat.Play();
        yield return StartCoroutine(bubbleshow.Bubble());
        //yield return new WaitForSeconds(WaitingTime_Cat);
        catClick.spriteRenderer.sprite = catClick.cat1;
        //Cat.SetActive(false);
        while (passwordManager.wrongAnswer) yield return null;
        AnswerBookScript.answerBookOn = false;
        BookSwitch.BookOn = false;
        answerbook.SetActive(false);


    }

    private IEnumerator GameOverCat()
    {
        catClick.spriteRenderer.sprite = catClick.cat2;
        bubbleshow.scriptNo = Noise - 1;
        audioSource_crow.Play();
        yield return new WaitForSeconds(WaitingTime_Crow);
        audioSource_cat.clip = ad[Random.Range(2, 5)];
        audioSource_cat.Play();
        yield return StartCoroutine(bubbleshow.Bubble());
        //yield return new WaitForSeconds(3f);
        savepassword.answer = null;
        PlayerPrefs.DeleteAll();
        StartCoroutine(TimerManager.timerStop());
        StartCoroutine(GameOver_Cat.ChangeScene(GameOver_Cat.Scenename));
    }
}
