using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public string Scenename;
    public GameObject FadeManager;
    public SettingPageManager SettingPageManager;


    private void OnMouseDown()
    {
        if (BookSwitch.BookOn == false && SettingPageManager.GamePaused == false && SceneManager.GetActiveScene().name != "Story_no1")
        {
            StartCoroutine(ChangeScene(Scenename));
        }
       
    }

    public IEnumerator ChangeScene(string Scenename)
    {
        yield return StartCoroutine(FadeManager.GetComponent<Fadeinout>().Fadeout());
        SceneManager.LoadScene(Scenename);
    }

    public void ChangeSceneAlt() //��ư�� �Ҵ��ϱ� ���� �ڷ�ƾ�� �ƴ� �Ϲ� �Լ��� �� �� �� ����
    {
        StartCoroutine(ChangeScene(Scenename));
    }

    public void ChangeSceneAlt(string _Scenename)
    {
        StartCoroutine(ChangeScene(_Scenename));
    }

    public void ExplainSceneRE()
    {
        SettingPageManager.SettingPageOff();
        StartCoroutine(ChangeScene("ExplainScene"));
    }

    public void BackToMain()
    {
        Time.timeScale = 1f;
        BookSwitch.BookOn = false;
        SettingPageManager.GamePaused = false;
        SpeechBubbleShow.bubbleOn = false;
        PlayerPrefs.DeleteAll();
        SettingPageManager.SettingPageOff();
        StartCoroutine(ChangeScene("Title"));
    }

}


