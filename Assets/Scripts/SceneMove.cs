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

    

}


