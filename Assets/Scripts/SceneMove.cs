using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public string Scenename;
    public GameObject FadeManager;


    private void OnMouseDown()
    {
        StartCoroutine(ChangeScene());
    }

    public IEnumerator ChangeScene()
    {
        yield return StartCoroutine(FadeManager.GetComponent<Fadeinout>().Fadeout());
        SceneManager.LoadScene(Scenename);
    }

    public void ChangeSceneAlt() //버튼에 할당하기 위해 코루틴이 아닌 일반 함수로 한 번 더 정의
    {
        StartCoroutine(ChangeScene());
    }

}


