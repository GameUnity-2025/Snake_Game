using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
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
    public void LoadSceneAtIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
