using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsUIHandler : MonoBehaviour
{
    public TMP_Dropdown first;
    public TMP_Dropdown second;
    public TMP_Dropdown third;
    public TMP_Dropdown fourth;
    public TMP_Dropdown fifth;
    public TMP_Dropdown sixth;
    
    // Start is called before the first frame update

    public void UpdateSettings()
    {
        DataManager.instance.settings.first = first.value;
        DataManager.instance.settings.second = second.value;
        DataManager.instance.settings.third = third.value;
        DataManager.instance.settings.fourth = fourth.value;
        DataManager.instance.settings.fifth = fifth.value;
        DataManager.instance.settings.sixth = sixth.value;
    }
    
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SaveSettings()
    {
        DataManager.instance.SaveSettings();
    }
    
    private void Awake()
    {
        LoadSettings();
    }

    private void LoadSettings()
    {
        first.value = DataManager.instance.settings.first;
        second.value = DataManager.instance.settings.second;
        third.value = DataManager.instance.settings.third;
        fourth.value = DataManager.instance.settings.fourth;
        fifth.value = DataManager.instance.settings.fifth;
        sixth.value = DataManager.instance.settings.sixth;
    }
}
