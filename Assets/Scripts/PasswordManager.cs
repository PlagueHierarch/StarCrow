using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public static class savepassword //Scene ��ȯ�ÿ��� ����� �����ϱ� ���� static �ʵ�
{
    public static string answer;
}

public class PasswordManager : MonoBehaviour
{
    // (password: �̸� ������ ��, answer: �÷��̾ ���� ������ ��)
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

        if (savepassword.answer == "0000") //���� �� ����
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
