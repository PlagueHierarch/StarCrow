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
    AudioSource audioSource_crow;
    public float WaitingTime_Crow = 0.6f;
    public float WaitingTime_Cat = 4.0f;
    public TimerManager TimerManager;
    public CatClick catClick;

    private void Awake()
    {
        audioSource_cat = Cat.GetComponent<AudioSource>();
        audioSource_crow = GetComponent<AudioSource>();
    }

    private void Start()
    {
        //Cat.SetActive(false);
    }
    public int Noise = 0;
    
    public void AddNoise()
    {
        Noise++;
        PlayerPrefs.SetInt("catCounter", Noise);
        if (Noise < 5) StartCoroutine(Warning());
        else StartCoroutine(GameOverCat());
    }

    public IEnumerator Warning()
    {
        catClick.spriteRenderer.sprite = catClick.cat2;
        audioSource_crow.Play();
        yield return new WaitForSeconds(WaitingTime_Crow);
        //Cat.SetActive(true);
        if (Noise <= 3) audioSource_cat.clip = ad[Random.Range(2, 5)];
        else audioSource_cat.clip = ad[Random.Range(0, 2)];
        audioSource_cat.Play();
        yield return new WaitForSeconds(WaitingTime_Cat);
        catClick.spriteRenderer.sprite = catClick.cat1;
        //Cat.SetActive(false);
        yield return null;
    }

    private IEnumerator GameOverCat()
    {
        yield return new WaitForSeconds(3f);
        savepassword.answer = null;
        PlayerPrefs.DeleteAll();
        StartCoroutine(TimerManager.timerStop());
        StartCoroutine(GameOver_Cat.ChangeScene(GameOver_Cat.Scenename));
    }
}
