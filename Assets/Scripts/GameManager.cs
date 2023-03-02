using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerMovement snake;
    [SerializeField] CanvasController canvas;
    [SerializeField] CollectiblesController collectibles;
    int score;
    void Start()
    {
        score = 0;
        canvas.UpdateScore(score);
    }
    public void FoodConsumed()
    {
        score += 10;
        snake.AddBody();
        canvas.UpdateScore(score);
        collectibles.SpawnFood();
    }
    public void PauseGameTrigger()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
        canvas.PauseScreenUI();
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        canvas.GameOverUI();
    }
    public void MainMenu()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        LevelManager.Instance.LoadMainMenu();
    }
    public void RestartLevel()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        LevelManager.Instance.ReloadCurrentLevel();
    }
    public void ExitGame()
    {
        LevelManager.Instance.QuitGame();
    }
}
