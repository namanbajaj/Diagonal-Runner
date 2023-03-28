using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool GameStarted;
    public bool GameEnded;

    public static bool firstSpace = true;

    public int Score;

    public TMP_Text ScoreText;

    private int HighScore;
    private bool isFirstTimePlaying;

    public void Awake()
    {
        HighScore = PlayerPrefs.GetInt("High Score", 0);
        isFirstTimePlaying = PlayerPrefs.GetInt("First Play", 1) == 1 ? true : false;
        GameEnded = false;

        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }

    public void StartGame()
    {
        GameStarted = true;
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
        GameEnded = true;
        PlayerPrefs.SetInt("High Score", Score > HighScore ? Score : HighScore);
    }

    private void Update()
    {
        if (InputDetected())
            StartGame();
    }

    public void IncreaseScore()
    {
        Score++;
        ScoreText.text = Score.ToString();
    }

    public bool InputDetected()
    {
        foreach (Touch touch in Input.touches)
            if (touch.phase == TouchPhase.Began)
                return true;

        return Input.GetKeyDown(KeyCode.Space);
    }
}
