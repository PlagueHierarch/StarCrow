using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoiseManagement : MonoBehaviour
{
    public GameObject Cat;
    public SceneMove GameOver_Cat;
    AudioSource audioSource_cat;
    AudioSource audioSource_crow;
    public float WaitingTime_Crow = 1.0f;
    public float WaitingTime_Cat = 4.0f;

    private void Awake()
    {
        audioSource_cat = Cat.GetComponent<AudioSource>();
        audioSource_crow = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Cat.SetActive(false);
    }
    private int Noise = 0;
    
    public void AddNoise()
    {
        Noise++;
        if (Noise < 5) StartCoroutine(Warning());
        else GameOverCat();
    }

    public IEnumerator Warning()
    {
        audioSource_crow.Play();
        yield return new WaitForSeconds(WaitingTime_Crow);
        Cat.SetActive(true);
        audioSource_cat.Play();
        yield return new WaitForSeconds(WaitingTime_Cat);
        Cat.SetActive(false);
        yield return null;
    }

    private void GameOverCat()
    {
        //시계 구현 시 타이머 멈추기
        StartCoroutine(GameOver_Cat.ChangeScene());
    }
}
