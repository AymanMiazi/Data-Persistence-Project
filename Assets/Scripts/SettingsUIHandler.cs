using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    private DataManager DM = DataManager.instance;
    // Start is called before the first frame update

    public void UpdateSettings()
    {
        DM.settings.first = DM.values[first.value];
        DM.settings.second = DM.values[second.value];
        DM.settings.third = DM.values[third.value];
        DM.settings.fourth = DM.values[fourth.value];
        DM.settings.fifth = DM.values[fifth.value];
        DM.settings.sixth = DM.values[sixth.value];
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
        first.value = Array.IndexOf(DM.values,DM.settings.first);
        second.value =Array.IndexOf(DM.values,DM.settings.second);
        third.value = Array.IndexOf(DM.values,DM.settings.third);
        fourth.value = Array.IndexOf(DM.values,DM.settings.fourth);
        fifth.value = Array.IndexOf(DM.values,DM.settings.fifth);
        sixth.value = Array.IndexOf(DM.values,DM.settings.sixth);
    }
}
