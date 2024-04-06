using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;

public static class UserSettingSave
{
    public static float gamma = 1;
    public static float audio_Main = 0.75f;
    public static float audio_Sfx = 1;
    public static float audio_Music = 1;
    public static FullScreenMode StFullscreenM;
    public static int StResolutionNum;
    public static bool isFull = true;

    public static void SetJson()
    {
        bool isClearTEMP = SettingJsonManager.Instance.settings.IsEverCleared;
        Settings settings = new()
        {
            _gamma = gamma,
            _audio_Main = audio_Main,
            _audio_Sfx = audio_Sfx,
            _audio_Music = audio_Music,
            _StFullscreenM = (int)StFullscreenM,
            _StResolutionNum = StResolutionNum,
            _isFull = isFull,
            IsEverCleared = isClearTEMP
        };

        SettingJsonManager.Instance.settings = settings;
    }

    public static void SetSettings()
    {
        Settings settings = SettingJsonManager.Instance.settings;
        gamma = settings._gamma;
        audio_Main = settings._audio_Main;
        audio_Sfx = settings._audio_Sfx;
        audio_Music = settings._audio_Music;
        StFullscreenM = (FullScreenMode)settings._StFullscreenM;
        StResolutionNum = settings._StResolutionNum;
        isFull = settings._isFull;

        Debug.Log("Parse Success");
    }
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
    public Dropdown DropdownResolution;
    public Toggle FullscreenToggle;
    List<Resolution>resolutions = new List<Resolution>();
    FullScreenMode fullscreenM;
    int resolutionNum;
    public static bool GamePaused = false;

    void Start()
    {
        SettingPage.SetActive(false);
        LoadSavedSetting();
        AudioControl_SFX();
        AudioControl_Music();
        AudioControl_Main();
        GammaControl();
        ResOption();
    }

    public void OpenSettingPage()
    {
        if (TimerManager.isStop == false)
        {
            StartCoroutine(TimerManager.timerStop()); //코루틴 중복 호출 제한
        }
        SettingPage.SetActive(true);
        
    }

    public void OpenSettingPageTitle()
    {
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
        SettingJsonManager.Instance.SaveSettings(false);
    }

    public void SettingPageOffTitle() //세팅 페이지의 나가기 버튼에 할당
    {
        SettingPage.SetActive(false);
        GamePaused = false;
    }
    public void QuitGame ()//에디터에선 작동 안됨(빌드 프로그램에선 정상 작동)
    {
        Application.Quit();
    }

    void ResOption()
    {
        resolutions.AddRange(Screen.resolutions);
        DropdownResolution.options.Clear();
        int optionNum = 0;
        foreach (Resolution item in resolutions)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " +item.refreshRateRatio + "hz";
            DropdownResolution.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height) DropdownResolution.value = optionNum;
            optionNum++;
        }
        DropdownResolution.RefreshShownValue();

        FullscreenToggle.isOn = UserSettingSave.isFull;
    }

    public void FullScToggle()
    {
        UserSettingSave.isFull = FullscreenToggle.isOn;
        fullscreenM = UserSettingSave.isFull?FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, fullscreenM, resolutions[resolutionNum].refreshRateRatio);
        Debug.Log(UserSettingSave.isFull);
    }

    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, fullscreenM, resolutions[resolutionNum].refreshRateRatio);
    }
}
