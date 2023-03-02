using UnityEngine;
using TMPro;
using System.Collections;

public class MPCanvas : MonoBehaviour
{
    [SerializeField] TMP_Text[] scores;
    [SerializeField] TMP_Text[] gameOverScore;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject pauseScreenUI;
    [SerializeField] TMP_Text winnerText;
    [SerializeField] GameObject[] helpTips;
    void Start()
    {
        StartCoroutine(HelpFlash());
    }
    public void UpdateScore(int[] _scores)
    {
        for (int i = 0; i < _scores.Length; i++)
        {
            scores[i].text = _scores[i].ToString();
        }
    }
    public void GameOverUI(int[] _scores)
    {
        int maxScore = 0;
        int playerid = 0;
        for (int i = 0; i < _scores.Length; i++)
        {
            gameOverScore[i].text = _scores[i].ToString();
            if (_scores[i] > maxScore)
            {
                maxScore = _scores[i];
                playerid = i + 1;
            }
        }
        if (_scores.Length > 1)
        {
            winnerText.text = "Player " + playerid + " is the winner!";
            winnerText.gameObject.SetActive(true);
        }
        gameOverUI.SetActive(true);
    }
    public void PauseScreenUI()
    {
        if (pauseScreenUI.activeInHierarchy)
            pauseScreenUI.SetActive(false);
        else
            pauseScreenUI.SetActive(true);
    }
    IEnumerator HelpFlash()
    {
        foreach (var item in helpTips)
        {
            item.SetActive(true);
        }
        yield return new WaitForSeconds(5f);
        foreach (var item in helpTips)
        {
            item.SetActive(false);
        }
    }
}
