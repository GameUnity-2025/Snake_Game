using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int score;
    [SerializeField] PlayerMovement snake;
    [SerializeField] CanvasController canvas;
    private static LevelManager instance = null;
    public static LevelManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }
    private void Start()
    {
        score = 0;
        canvas.UpdateScore(score);
    }
    public void FoodConsumed()
    {
        score += 10;
        snake.AddBody();
        canvas.UpdateScore(score);
    }
    public void PauseGame()
    {
        canvas.PauseScreenTrigger();
    }
    public void GameOver()
    {
        canvas.GameOverEnable();
    }
}
