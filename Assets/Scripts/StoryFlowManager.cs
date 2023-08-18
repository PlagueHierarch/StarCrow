using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.Windows.WebCam;

public class StoryFlowManager : MonoBehaviour
{
   
    public bool UsingTimer = false;
    public GameObject ProceedButton = null;
    
    public float dialogTime = 0f;//진행 버튼이 나오기까지의 시간
    public GameObject Story1 = null;
    public GameObject Story2 = null;
    public VideoPlayer vid = null;
    private void Awake()
    { 
        ProceedButton.SetActive(false);
        if (SceneManager.GetActiveScene().name == "DoorOpen")
        { 
            Story1.SetActive(true);
            Story2.SetActive(false);
        }
    }
    private void Start()
    {
        StartCoroutine(StoryWaitingTime());
        if (SceneManager.GetActiveScene().name == "DoorOpen")
        {
            StartCoroutine(SceneDoorOpen());
        }
    }
    IEnumerator StoryWaitingTime()
    {
        yield return new WaitForSeconds(dialogTime);
        ProceedButton.SetActive(true);
    }
    IEnumerator SceneDoorOpen()
    {
        yield return new WaitForSeconds(3);
        Story1.SetActive(false);
        Story2.SetActive(true);
        yield return new WaitForSeconds(2);
        vid.Play();
        yield return new WaitForSeconds(1);
        GameObject.Find("Story2").SetActive(false);
        yield return null;
    }
}
