using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class UserSave
{
    public static bool tutorial = true;//메인 씬 튜토리얼 진행 후 false(튜토리얼 재생 방지용)
}
public class StoryFlowManager : MonoBehaviour
{
    public SettingPageManager PageManager;
    
    public bool UsingTimer = false;
    public bool UsingOptions = false;
    public GameObject Options = null;
    
    public float dialogTime = 0f;//선택지나 진행 버튼이 나오기까지의 시간
    
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
    public void caseOption1() //선택지 선택 후 대사 또는 딜레이가 있는 경우
    {
        StartCoroutine(choice1());   
    }
    IEnumerator choice1()
    {
        //대사 등 SetActive용 필드
        yield return new WaitForSeconds(laterDialogtime);
    }
    public void caseOption2() //그 외
    {
        //Scene 전환 등 함수용 필드
    }

    public void Tutorial()//bool tutorial이 true일 때 한번 호출
    {
        //게임 진행 방법 설명
    }
}
