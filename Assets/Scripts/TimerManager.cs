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
    public bool isStop = false; //bool ������ ���� �߻�
    public SceneMove GameOver_Timer;
    public AudioSource audiosource_Warning;
    public float curTime; //���� ���� private�� �����
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
            yield return new WaitForSeconds(1);//���� �� ��Ȱ��ȭ
            if ((int)curTime == warning1 || (int)curTime == warning2)
            {
                //�ð�ž ���(��ǳ��)
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

    public IEnumerator timerStop() //������ ��ġ�� �ʵ��� Ÿ�̸� �ƿ� ����
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
