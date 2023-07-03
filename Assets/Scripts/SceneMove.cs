using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public string Scenename;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(Scenename);
    }

    }
