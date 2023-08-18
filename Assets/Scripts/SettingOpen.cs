using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingOpen : MonoBehaviour
{
   public SettingPageManager SettingPageManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P) && SettingPageManager.GamePaused == false)
        {
            //Debug.Log("paused");
            Time.timeScale = 0f;
            SettingPageManager.OpenSettingPage();
            SettingPageManager.GamePaused = true;
        }
    }
}
