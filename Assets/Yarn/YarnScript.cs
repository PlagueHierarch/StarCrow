using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class YarnScript : MonoBehaviour
{
    public GameObject crow;
    public GameObject cat;
    public GameObject bubble;
    public VerticalLayoutGroup OptionList;
    bool optionON = false;

    Vector3 crowpos;
    Vector3 catpos;

    public void Awake()
    {
        crowpos = crow.transform.position;
        catpos = cat.transform.position;
    }

    public void Update()
    {
        if(optionON == true)
        {
            OptionList.spacing = 41;
        }
        
    }

    [YarnCommand("changescene")]
    public void ChangeScene(string sceneName)
    {
        StartCoroutine(gameObject.GetComponent<SceneMove>().ChangeScene(sceneName));
    }

    [YarnCommand("changepos")]
    public void ChangePos(string obj)
    {
        if (obj == "crow")
        {
            bubble.transform.position = crowpos;
        }

        else
        {
            bubble.transform.position = catpos;
        }
    }

    [YarnCommand("optionlistverticalON")]
    public void OptionListVerticalON()
    {
        optionON = true;
    }

    [YarnCommand("optionlistverticalOFF")]
    public void OptionListVerticalOFF()
    {
        optionON = false;
    }
}
