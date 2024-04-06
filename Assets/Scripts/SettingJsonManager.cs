using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class SettingJsonManager : MonoBehaviour
{
    private static SettingJsonManager instance;
    public static SettingJsonManager Instance {  get { return instance; } } //싱글톤 구조


    private string direction; //파일 IO를 위한 경로
    public Settings settings = new();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(this);
            return;
        }

        direction = Application.dataPath + "/Data.json";
        Debug.Log(direction);
        if (File.Exists(direction))
        {
            ParseSettings();
        }
        else
        {
            //게임 다운로드 후 첫 시작에서만 실행, 기본 설정 삽입.
            FileStream JsonFile = File.Create(direction);
            JsonFile.Close(); //첫 파일 세이브를 위해 우선 열려있는 해당 파일을 닫아줌
            SaveSettings(true);
        }
    }

    public void ParseSettings()
    {
        string json = File.ReadAllText(direction);
        if (json == null || json == "")
        {
            Debug.LogWarning("Json Is Null");
            SaveSettings(false);
            return;
        }
        settings = JsonUtility.FromJson<Settings>(json);
        UserSettingSave.SetSettings();
    }

    public void SaveSettings(bool isInit)
    {
        UserSettingSave.SetJson();
        if (isInit)
        {
            settings.IsEverCleared = false; //파일 생성시에만 호출됨. 세이브 파일을 지우지 않는 한 클리어 기록을 덮어쓰는 일은 없음.
        }
        string text = JsonUtility.ToJson(settings, true);
        File.WriteAllText(direction, text);
            
        Debug.Log("Save Success");
    }

    public bool isCleared() { return settings.IsEverCleared; }

    public void SetClear() //게임 클리어 시 해당 정보 저장. 초반 대화를 제외한 엔딩에서만 호출
    {
        settings.IsEverCleared = true;
        SaveSettings(false);
    }
}

[Serializable]
public class Settings 
{
    public float _gamma;
    public float _audio_Main;
    public float _audio_Sfx;
    public float _audio_Music;
    public int _StFullscreenM; //original form is FullScreenMode
    public int _StResolutionNum;
    public bool _isFull;

    public bool IsEverCleared = false;
}

