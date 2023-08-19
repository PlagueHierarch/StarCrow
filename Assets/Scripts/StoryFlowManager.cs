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
    
    public float dialogTime = 0f;//���� ��ư�� ����������� �ð�
    private void Awake()
    { 
        ProceedButton.SetActive(false);
    }
    private void Start()
    {
        StartCoroutine(StoryWaitingTime());
    }
    IEnumerator StoryWaitingTime()
    {
        yield return new WaitForSeconds(dialogTime);
        ProceedButton.SetActive(true);
    }

}
