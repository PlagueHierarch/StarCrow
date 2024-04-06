using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateClearInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SettingJsonManager.Instance.SetClear();
    }
}
