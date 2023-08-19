using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public static class UserSettingSave
{
    public static float gamma = 1;
    public static float audio_Main = 1;
    public static float audio_Sfx = 1;
    public static float audio_Music = 1;
}
public class SettingPageManager : MonoBehaviour
{
    public GameObject SettingPage;
    public TimerManager TimerManager;
    public AudioMixer MasterVolume;
    public Slider MasterSlider;
    public Slider SFXSlider;
    public Slider GammaSlider;
    public Slider MusicSlider;
    public CanvasGroup GammaImage;

    public static bool GamePaused = false;

    void Start()
    {
        SettingPage.SetActive(false);
        Debug.Log(UserSettingSave.audio_Sfx);
        LoadSavedSetting();
        AudioControl_SFX();
        AudioControl_Music();
        AudioControl_Main();
        GammaControl();
    }

    public void OpenSettingPage()
    {
        if (TimerManager.isStop == false)
        {
            StartCoroutine(TimerManager.timerStop()); //코루틴 중복 호출 제한
        }
        SettingPage.SetActive(true);
        
    }
    
    public float Lerp(float volmin, float volmax, float slidervalue)
    {
        float volume = volmin + (volmax - volmin) * slidervalue;
        if (slidervalue == 0) volume = -80;
        return volume;
    }
    void LoadSavedSetting()
    {
        MasterSlider.value = UserSettingSave.audio_Main;
        SFXSlider.value = UserSettingSave.audio_Sfx;
        MusicSlider.value = UserSettingSave.audio_Music;
        GammaSlider.value = UserSettingSave.gamma;
    }
    public void AudioControl_Main()
    {
        UserSettingSave.audio_Main = MasterSlider.value;
        MasterVolume.SetFloat("Volume_Main", Lerp(-20, 10, MasterSlider.value));
    }
    public void AudioControl_SFX()
    {
        UserSettingSave.audio_Sfx = SFXSlider.value;
        MasterVolume.SetFloat("Volume_SFX", Lerp(-20, 10, SFXSlider.value));
        Debug.Log(UserSettingSave.audio_Sfx);
    }
    public void AudioControl_Music()
    {
        UserSettingSave.audio_Music = MusicSlider.value;
        MasterVolume.SetFloat("Volume_Music", Lerp(-20, 10, MusicSlider.value));

    }
    public void GammaControl()
    {
        UserSettingSave.gamma = GammaSlider.value;
        GammaImage.alpha = 1 - UserSettingSave.gamma;
    }

    public void SettingPageOff() //세팅 페이지의 나가기 버튼에 할당
    {
        Time.timeScale = 1f;
        TimerManager.timerRestart();
        SettingPage.SetActive(false);
        GamePaused = false;
    }
    public void QuitGame ()//에디터에선 작동 안됨(빌드 프로그램에선 정상 작동)
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
