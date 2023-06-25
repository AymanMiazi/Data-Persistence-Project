using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text highScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

        if (DataManager.instance.highScores.firstScore > 0)
        {
            SetHighScore();
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        if (DataManager.instance.highScores.firstScore < m_Points)
        {
            SetDataFirst();
            SetHighScore();
            return;
        }

        if (DataManager.instance.highScores.secondScore < m_Points)
        {
            SetDataSecond();
            SetHighScore();
            return;
        }

        if (DataManager.instance.highScores.thirdScore < m_Points)
        {
            SetDataThird();
            SetHighScore();
        }
    }

    public void SetDataFirst()
    {
        DataManager.instance.highScores.thirdScore = DataManager.instance.highScores.secondScore;
        DataManager.instance.highScorePlayerNames.third = DataManager.instance.highScorePlayerNames.second;
        DataManager.instance.highScores.secondScore = DataManager.instance.highScores.firstScore;
        DataManager.instance.highScorePlayerNames.second = DataManager.instance.highScorePlayerNames.first;
        DataManager.instance.highScores.firstScore = m_Points;
        DataManager.instance.highScorePlayerNames.first = DataManager.instance.playerName;
    }

    public void SetDataSecond()
    {
        DataManager.instance.highScores.thirdScore = DataManager.instance.highScores.secondScore;
        DataManager.instance.highScorePlayerNames.third = DataManager.instance.highScorePlayerNames.second;
        DataManager.instance.highScores.secondScore = m_Points;
        DataManager.instance.highScorePlayerNames.second = DataManager.instance.playerName;
    }

    public void SetDataThird()
    {
        DataManager.instance.highScores.thirdScore = m_Points;
        DataManager.instance.highScorePlayerNames.third = DataManager.instance.playerName;
    }
    public void SetHighScore()
    {
        
        highScoreText.text = $"Best Score : {DataManager.instance.highScorePlayerNames.first} : {DataManager.instance.highScores.firstScore}";
        DataManager.instance.SaveScore();
    }
}
