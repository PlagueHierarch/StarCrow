using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public static class UserSettingSave
{
    public static float gamma = 1;
    public static float audio_Main = 0;
    public static float audio_Sfx = 0;
    //public static float audio_Music;
}
public class SettingPageManager : MonoBehaviour
{
    public GameObject SettingPage;
    public TimerManager TimerManager;
    public AudioMixer MasterVolume;
    public Slider MasterSlider;
    public Slider SFXSlider;
    public Slider GammaSlider;
    public CanvasGroup GammaImage;

    void Start()
    {
        SettingPage.SetActive(false);
        AudioControl();
        GammaControl();
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

    public float Lerp(float s, float e, float t)
    {
        return s + (e - s) * t;
    }
    public void AudioControl()
    {
        UserSettingSave.audio_Main = Lerp(-40, 10, MasterSlider.value);
        MasterVolume.SetFloat("Volume_Main", UserSettingSave.audio_Main);

        UserSettingSave.audio_Sfx = Lerp(-40, 10, SFXSlider.value);
        MasterVolume.SetFloat("Volume_SFX", UserSettingSave.audio_Sfx);

        Debug.Log("Volume Change");
        //UserSettingSave.audio_Music = MusicSlider.value; //--> BGM 삽입 이후 슬라이더 추가 및 설정
        //MasterVolume.SetFloat("Volume_Music", UserSettingSave.audio_Music);
    }

    public void GammaControl()
    {
        UserSettingSave.gamma = GammaSlider.value;
        GammaImage.alpha = 1 - UserSettingSave.gamma;
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
