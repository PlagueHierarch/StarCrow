using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class UserSave
{
    public static bool tutorial = true;//���� �� Ʃ�丮�� ���� �� false(Ʃ�丮�� ��� ������)
}
public class StoryFlowManager : MonoBehaviour
{
    public SettingPageManager PageManager;
    
    public bool UsingTimer = false;
    public bool UsingOptions = false;
    public GameObject Options = null;
    
    public float dialogTime = 0f;//�������� ���� ��ư�� ����������� �ð�
    
    public float laterDialogtime = 0f;
    private void Awake()
    {
        if (UsingOptions == true) Options.SetActive(false);        
    }
    private void Start()
    {
        if (UsingOptions == true) StartCoroutine(OptionActive());
    }
    private void Update()
    {
        if (UsingTimer == false && PageManager.TimerManager.isStop == false)
        {
            PageManager.TimerManager.isStop = true;
            PageManager.TimerManager.curTime = 1800f;
        }
    }
    IEnumerator OptionActive()
    {
        yield return new WaitForSeconds(dialogTime);
        Options.SetActive(true);
        yield return null;
    }
    public void caseOption1() //������ ���� �� ��� �Ǵ� �����̰� �ִ� ���
    {
        StartCoroutine(choice1());   
    }
    IEnumerator choice1()
    {
        //��� �� SetActive�� �ʵ�
        yield return new WaitForSeconds(laterDialogtime);
    }
    public void caseOption2() //�� ��
    {
        //Scene ��ȯ �� �Լ��� �ʵ�
    }

    public void Tutorial()//bool tutorial�� true�� �� �ѹ� ȣ��
    {
        //���� ���� ��� ����
    }
}
