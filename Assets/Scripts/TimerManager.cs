using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Timer
{
    public static float time = 1800.0f;
}

public class TimerManager : MonoBehaviour
{   
    public bool isStop = false; //bool 수정시 버그 발생
    public SceneMove GameOver_Timer;
    public AudioSource audiosource_Warning;
    public float curTime; //빌드 전에 private로 만들기
    public int warning1 = 1200;
    public int warning2 = 600;
    public NoiseManagement noise;
    void Start()
    {
        StartCoroutine(timerStart());
        StartCoroutine(CheckTime());
    }

    public IEnumerator timerStart()
    {
        curTime = Timer.time;
        while (curTime > 0)
        {
            curTime -= Time.deltaTime;
            Timer.time = curTime;
            yield return null;
            if (isStop == true) yield break;    
        }
        
        yield return null;
    }
    IEnumerator CheckTime()
    {
        while (curTime > 0)
        {
            //Debug.Log((int)curTime);
            yield return new WaitForSeconds(1);//빌드 전 비활성화
            if ((int)curTime == warning1 || (int)curTime == warning2)
            {
                //시계탑 경고(말풍선)
                audiosource_Warning.Play();
                StartCoroutine(gameObject.GetComponent<SpeechBubbleShow>().Bubble());
                gameObject.GetComponent<SpeechBubbleShow>().scriptNo++;
                //Debug.Log("warning");
                noise.audioSource_crow.Play();
                yield return new WaitForSeconds(1);
                audiosource_Warning.Play();
            }
            if ((int)curTime == 0)
            {
                yield return StartCoroutine(gameObject.GetComponent<SceneMove>().ChangeScene(gameObject.GetComponent<SceneMove>().Scenename));
                yield break;
            }
            yield return null;
        }
        yield return null;
    }

    public IEnumerator timerStop() //엔딩이 겹치지 않도록 타이머 아예 정지
    {
        isStop = true;
        yield return null;
    }
    
    public void timerRestart()
    {
        isStop = false;
        StartCoroutine(timerStart());
    }
}
