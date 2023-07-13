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
                StartCoroutine(TimerManager.timerStop()); //�ڷ�ƾ �ߺ� ȣ�� ����
            }
            SettingPage.SetActive(true);
        }
    }
    public void SettingPageOff() //���� �������� ������ ��ư�� �Ҵ�
    {
        TimerManager.timerRestart();
        SettingPage.SetActive(false);
    }
    public void QuitGame ()//�����Ϳ��� �۵� �ȵ�(���� ���α׷����� ���� �۵�)
    {
        Application.Quit();
    }
}
