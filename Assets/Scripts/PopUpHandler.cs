using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpHandler : MonoBehaviour
{
    public TMP_Text GameScore;
    public TMP_Text HighScore;

    private GameManager GM;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }

    public void Show(int score, int highScore)
    {
        GameScore.text = "Score: " + score.ToString();
        HighScore.text = "High Score: " + highScore.ToString();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void PlayClicked()
    {
        GM.StartGame();
    }

}
