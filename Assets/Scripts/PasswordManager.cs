using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PasswordManager : MonoBehaviour
{
    // (password: �̸� ������ ��, answer: �÷��̾ ���� ������ ��)
    public string answer;
    public string password;

    public InputField answersubmitter;
    public Button Button;
    public NoiseManagement noiseObject;
    public SceneMove DoorOpen;

    private void Start()
    {
        answersubmitter.text = answer;
    }

    public void SubmitAnswer()
    {
        answer = answersubmitter.text;
    }

    public void CheckAnswer()
    {
        if (answer != password && answer != "") wrong();

        else if (answer == password) right();
    }
    private void wrong()
    {
        noiseObject.AddNoise();
        Debug.Log(answer);
    }

    private void right()
    {
        StartCoroutine(DoorOpen.ChangeScene());
        //�ð� ���� �� Ÿ�̸� ���߱�
    }
}
