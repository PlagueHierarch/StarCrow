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
    public GameObject nextScene;
    
    public float dialogTime = 0f;//진행 버튼이 나오기까지의 시간
    private void Awake()
    {
        nextScene.GetComponent<BoxCollider2D>().enabled = false;
        ProceedButton.SetActive(false);
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Story_no1")
        {
            Debug.Log("Scene Detected");
            GameObject.Find("Btn_skip").SetActive(SettingJsonManager.Instance.isCleared());
        }
        StartCoroutine(StoryWaitingTime());
    }
    IEnumerator StoryWaitingTime()
    {
        yield return new WaitForSeconds(dialogTime);
        nextScene.GetComponent<BoxCollider2D>().enabled = true;
        ProceedButton.SetActive(true);
    }
}
