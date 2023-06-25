using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
   public void StartGame()
   {
      SceneManager.LoadScene(1);
   }

   public void HighScores()
   {
      SceneManager.LoadScene(2);
   }

   public void ExitGame()
   {
#if UNITY_EDITOR
      UnityEditor.EditorApplication.ExitPlaymode();
#else
      Application.Quit();
#endif
   }

   public void SaveName(string playerName)
   {
      DataManager.instance.playerName = playerName;
   }

   public void Settings()
   {
      SceneManager.LoadScene(3);
   }
}
