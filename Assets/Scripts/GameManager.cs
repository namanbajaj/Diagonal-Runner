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

    public int Score = 0;

    public TMP_Text ScoreText;

    private int HighScore;
    private bool isFirstTimePlaying;

    public PopUpHandler ScorePopUp;

    public void Awake()
    {
        HighScore = PlayerPrefs.GetInt("High Score", 0);
        isFirstTimePlaying = PlayerPrefs.GetInt("First Play") == 0;
        if (isFirstTimePlaying)
        {
            PlayerPrefs.SetInt("Vibrate", 1);
            PlayerPrefs.SetInt("Sound", 1);
            PlayerPrefs.SetInt("First Play", 1);
        }

        Application.targetFrameRate = Screen.currentResolution.refreshRate;

        //ScorePopUp.Hide();
        ScorePopUp.Show(PlayerPrefs.GetInt("LastGameScore"), HighScore);
    }

    public void StartGame()
    {
        GameStarted = true;
        ScorePopUp.Hide();
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("High Score", Score > HighScore ? Score : HighScore);
        ScorePopUp.Show(Score, HighScore);
        PlayerPrefs.SetInt("LastGameScore", Score);
        GameStarted = false;
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
            if (touch.phase == TouchPhase.Began && GameStarted)
                return true;

        return false;
    }
}
