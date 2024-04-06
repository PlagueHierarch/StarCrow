using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class SettingJsonManager : MonoBehaviour
{
    private static SettingJsonManager instance;
    public static SettingJsonManager Instance {  get { return instance; } } //�̱��� ����


    private string direction; //���� IO�� ���� ���
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
            //���� �ٿ�ε� �� ù ���ۿ����� ����, �⺻ ���� ����.
            FileStream JsonFile = File.Create(direction);
            JsonFile.Close(); //ù ���� ���̺긦 ���� �켱 �����ִ� �ش� ������ �ݾ���
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
            settings.IsEverCleared = false; //���� �����ÿ��� ȣ���. ���̺� ������ ������ �ʴ� �� Ŭ���� ����� ����� ���� ����.
        }
        string text = JsonUtility.ToJson(settings, true);
        File.WriteAllText(direction, text);
            
        Debug.Log("Save Success");
    }

    public bool isCleared() { return settings.IsEverCleared; }

    public void SetClear() //���� Ŭ���� �� �ش� ���� ����. �ʹ� ��ȭ�� ������ ���������� ȣ��
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

