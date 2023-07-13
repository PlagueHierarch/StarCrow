using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPageManager : MonoBehaviour
{
    public GameObject SettingPage;
    public TimerManager TimerManager;
    void Start()
    {
        SettingPage.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            
            if (TimerManager.isStop == false)
            {
                StartCoroutine(TimerManager.timerStop()); //코루틴 중복 호출 제한
            }
            SettingPage.SetActive(true);
        }
    }
    public void SettingPageOff() //세팅 페이지의 나가기 버튼에 할당
    {
        TimerManager.timerRestart();
        SettingPage.SetActive(false);
    }
    public void QuitGame ()//에디터에선 작동 안됨(빌드 프로그램에선 정상 작동)
    {
        Application.Quit();
    }
}
