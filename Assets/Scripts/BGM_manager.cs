using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM_manager : MonoBehaviour
{
    public GameObject BGM_Management;
    AudioSource BGM;
    AudioSource BGM_Compare = null;
    string curSceneName;
    string SceneName;
    private void Awake()
    {
        StartCoroutine(StartBGM());
    }
    
    private void Update()
    {
        SceneName = SceneManager.GetActiveScene().name;
        if (SceneName != curSceneName)
        {
            if (SceneName == "Title")
            {
                Destroy(BGM_Management);
            }
            Debug.Log("Scene Changed");  
            StartCoroutine(CompareBGMs());
            BGM_Compare = null;
            curSceneName = SceneName;
        }
    }
    IEnumerator CompareBGMs()
    {
        //yield return new WaitForSeconds(1);
        BGM_Compare = GameObject.Find("Bgm").GetComponent<AudioSource>();
        if (BGM.clip != BGM_Compare.clip)
        {
            BGM.Stop();
            Debug.Log("Changing");
            BGM.clip = BGM_Compare.clip;
            BGM.volume = BGM_Compare.volume;
            BGM.Play();
            yield return null;
        }
        yield return null;
    }

    IEnumerator StartBGM()
    {
        curSceneName = SceneManager.GetActiveScene().name;
        BGM = BGM_Management.GetComponent<AudioSource>();
        if (BGM.isPlaying) yield break;
        else
        {
            BGM.Play();
            DontDestroyOnLoad(BGM_Management);
        }
        yield return null;
    }
}
