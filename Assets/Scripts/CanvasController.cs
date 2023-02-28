using UnityEngine;
using TMPro;
public class CanvasController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMP_Text gameOverScore;
    [SerializeField] GameObject pauseScreenUI;
    public void UpdateScore(int _score)
    {
        scoreText.text = _score.ToString();
    }
    public void GameOverUI()
    {
        gameOverScore.text = scoreText.text;
        gameOverUI.SetActive(true);
    }
    public void PauseScreenUI()
    {
        if (pauseScreenUI.activeInHierarchy)
        {
            pauseScreenUI.SetActive(false);
        }
        else
        {
            pauseScreenUI.SetActive(true);
        }
    }
}
