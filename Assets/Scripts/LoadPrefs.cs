using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPrefs : MonoBehaviour
{
    public mouseClick mouseClick;
    public NoiseManagement noiseManagement;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("mouseClick"))
        {
            mouseClick.clickCount = PlayerPrefs.GetInt("mouseClick"); 
        }

        if (PlayerPrefs.HasKey("catCounter"))
        {
            noiseManagement.Noise = PlayerPrefs.GetInt("catCounter");
        }

        gameObject.SetActive(false);
    }
}
