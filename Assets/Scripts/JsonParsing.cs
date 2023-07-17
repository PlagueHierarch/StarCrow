using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonParsing : MonoBehaviour
{
    public ScriptData line;

    private void Start()
    {
        TextAsset textasset = Resources.Load<TextAsset>("Json/dialogues");
        line = JsonUtility.FromJson<ScriptData>(textasset.text);
        //Debug.Log(line.Dialogues[0].Dialogue[0].text);
        //Debug.Log(line.Dialogues[1].obj);
    }

    void ParseJson()
    {
      
    }

    [Serializable]
    public class info
    {
        public string obj;
        public lines[] Dialogue;
    }

    [Serializable]
    public class lines
    {
        public string text;
    }

    [Serializable]
    public class ScriptData
    {
        public List<info> Dialogues;
    }
}
