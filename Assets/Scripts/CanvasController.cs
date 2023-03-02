using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject pauseScreenUI;
    public void UpdateScore(int _score)
    {
        scoreText.text = _score.ToString();
    }
    public void GameOverEnable()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }
    public void PauseScreenTrigger()
    {
        if (pauseScreenUI.activeInHierarchy)
        {
            pauseScreenUI.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseScreenUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
