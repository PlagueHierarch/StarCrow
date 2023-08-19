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

    public int hisscounter;
    public GameObject dialogueManager;
    public SpeechBubbleShow bubbleshow;

    private bool wrongAnswer;

    private void Start()
    {
        answersubmitter.text = savepassword.answer;
        bubbleshow = dialogueManager.GetComponent<SpeechBubbleShow>();
        hisscounter = 0;
        wrongAnswer = false;
    }

    public void SubmitAnswer()
    {
        savepassword.answer = answersubmitter.text;
    }

    public void CheckAnswer()
    {
        if (wrongAnswer == false && SpeechBubbleShow.bubbleOn == false)
        {
            if (savepassword.answer != password && savepassword.answer != null) StartCoroutine(wrong());

            else if (savepassword.answer == password) right();
        }

        if (savepassword.answer == "1210") //빌드 전 삭제
        {
            TimerManager.curTime = 1210;
        }
        else if (savepassword.answer == "0610") TimerManager.curTime = 610;
    }
    private IEnumerator wrong()
    {
        wrongAnswer = true;
        noiseObject.AddNoise();
        bubbleshow.scriptNo = hisscounter;
        Debug.Log(savepassword.answer);
        yield return StartCoroutine(bubbleshow.Bubble());
        hisscounter++;
        wrongAnswer = false;
    }

    private void right()
    {
        savepassword.answer = null;
        StartCoroutine(TimerManager.timerStop());
        StartCoroutine(DoorOpen.ChangeScene(DoorOpen.Scenename));
    }
}
