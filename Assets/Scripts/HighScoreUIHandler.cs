using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HighScoreUIHandler : MonoBehaviour
{
    public TextMeshProUGUI first;
    public TextMeshProUGUI  second;
    public TextMeshProUGUI  third;
    
    // Start is called before the first frame update
    void Awake()
    {
        first.text = $"1 : {DataManager.instance.highScorePlayerNames.first} : {DataManager.instance.highScores.firstScore}";
        second.text = $"2 : {DataManager.instance.highScorePlayerNames.second} : {DataManager.instance.highScores.secondScore}";
        third.text = $"3 : {DataManager.instance.highScorePlayerNames.third} : {DataManager.instance.highScores.thirdScore}";
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
