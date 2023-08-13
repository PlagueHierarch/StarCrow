using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public static class savepassword //Scene 전환시에도 답안을 유지하기 위한 static 필드
{
    public static string answer;
}

public class PasswordManager : MonoBehaviour
{
    // (password: 미리 정해진 답, answer: 플레이어가 최종 제출한 답)
    public string password;
    public InputField answersubmitter;
    public NoiseManagement noiseObject;
    public SceneMove DoorOpen;
    public TimerManager TimerManager;

    private void Start()
    {
        answersubmitter.text = savepassword.answer;
    }

    public void SubmitAnswer()
    {
        savepassword.answer = answersubmitter.text;
    }

    public void CheckAnswer()
    {
        if (savepassword.answer != password && savepassword.answer != "") wrong();

        else if (savepassword.answer == password) right();

        if (savepassword.answer == "0000") //빌드 전 삭제
        {
            TimerManager.curTime = 10;
        }
    }
    private void wrong()
    {
        noiseObject.AddNoise();
        Debug.Log(savepassword.answer);
    }

    private void right()
    {
        StartCoroutine(TimerManager.timerStop());
        StartCoroutine(DoorOpen.ChangeScene(DoorOpen.Scenename));
    }
}
