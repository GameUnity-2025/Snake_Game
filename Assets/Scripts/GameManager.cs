using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerMovement[] player;
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
        AudioManager.Instance.PlaySound(SoundType.Food);
        score += 10;
        player[0].AddBody();
        canvas.UpdateScore(score);
        collectibles.SpawnFood();
    }
    public void PauseGameTrigger()
    {
        AudioManager.Instance.PlaySound(SoundType.Button);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
        canvas.PauseScreenUI();
    }
    public void GameOver()
    {
        AudioManager.Instance.PlaySound(SoundType.GameOver);
        Time.timeScale = 0;
        canvas.GameOverUI();
    }
    public void MainMenu()
    {
        AudioManager.Instance.PlaySound(SoundType.Button);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        LevelManager.Instance.LoadMainMenu();
    }
    public void RestartLevel()
    {
        AudioManager.Instance.PlaySound(SoundType.Button);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        LevelManager.Instance.ReloadCurrentLevel();
    }
    public void ExitGame()
    {
        AudioManager.Instance.PlaySound(SoundType.Button);
        LevelManager.Instance.QuitGame();
    }
}
