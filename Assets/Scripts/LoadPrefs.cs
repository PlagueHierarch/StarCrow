using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPrefs : MonoBehaviour
{
    public NoiseManagement noiseManagement;
    private void Awake()
    {
        BookSwitch.BookOn = false;
        SettingPageManager.GamePaused = false;
        SpeechBubbleShow.bubbleOn = false;

        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            mouseClick mouseClick = GameObject.FindWithTag("mouse").GetComponent<mouseClick>();

            if (PlayerPrefs.HasKey("mouseClick"))
            {
                mouseClick.clickCount = PlayerPrefs.GetInt("mouseClick");
            }

            if (PlayerPrefs.HasKey("catCounter"))
            {
                noiseManagement.Noise = PlayerPrefs.GetInt("catCounter");
            }
        }
        
        if(SceneManager.GetActiveScene().name == "Bookshelf")
        {
            ShowBook showbook4 = GameObject.FindWithTag("book4").GetComponent<ShowBook>();
            if (PlayerPrefs.HasKey("darkPage"))
            {
                showbook4.pages[0] = showbook4.pages[1];
            }
        }

        gameObject.SetActive(false);
    }
}
