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
        LoadSavedSetting();
        AudioControl();
        GammaControl();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P) && GamePaused == false )
        {
            Time.timeScale = 0f;
            OpenSettingPage();
            GamePaused = true;
        }
    }
    public void OpenSettingPage()
    {
        if (TimerManager.isStop == false)
        {
            StartCoroutine(TimerManager.timerStop()); //�ڷ�ƾ �ߺ� ȣ�� ����
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
    public void AudioControl()
    {
        UserSettingSave.audio_Main = MasterSlider.value;
        MasterVolume.SetFloat("Volume_Main", Lerp(-20, 10, MasterSlider.value));

        UserSettingSave.audio_Sfx = SFXSlider.value;
        MasterVolume.SetFloat("Volume_SFX", Lerp(-20, 10, SFXSlider.value));

        UserSettingSave.audio_Music = MusicSlider.value;
        MasterVolume.SetFloat("Volume_Music", Lerp(-20, 10, MusicSlider.value));
    }

    public void GammaControl()
    {
        UserSettingSave.gamma = GammaSlider.value;
        GammaImage.alpha = 1 - UserSettingSave.gamma;
    }

    public void SettingPageOff() //���� �������� ������ ��ư�� �Ҵ�
    {
        Time.timeScale = 1f;
        TimerManager.timerRestart();
        SettingPage.SetActive(false);
        GamePaused = false;
    }
    public void QuitGame ()//�����Ϳ��� �۵� �ȵ�(���� ���α׷����� ���� �۵�)
    {
        Application.Quit();
    }
}
