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
        if (BookSwitch.BookOn == false && SettingPageManager.GamePaused == false)
        {
            StartCoroutine(ChangeScene(Scenename));
        }
       
    }

    public IEnumerator ChangeScene(string Scenename)
    {
        yield return StartCoroutine(FadeManager.GetComponent<Fadeinout>().Fadeout());
        SceneManager.LoadScene(Scenename);
    }

    public void ChangeSceneAlt() //버튼에 할당하기 위해 코루틴이 아닌 일반 함수로 한 번 더 정의
    {
        StartCoroutine(ChangeScene(Scenename));
    }

    public void ExplainSceneRE()
    {
        SettingPageManager.SettingPageOff();
        StartCoroutine(ChangeScene("ExplainScene"));
    }

    public void BackToMain()
    {
        SettingPageManager.SettingPageOff();
        StartCoroutine(ChangeScene("Title"));
    }

}


