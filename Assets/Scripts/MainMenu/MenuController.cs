using UnityEngine;
public class MenuController : MonoBehaviour
{
    [SerializeField] CanvasGroup MainMenu;
    [SerializeField] GameObject PlayMenu;
    [SerializeField] GameObject SettingsMenu;
    public void StartClicked()
    {
        MainMenu.alpha = 0.5f;
        MainMenu.interactable = false;
        if (!PlayMenu.activeInHierarchy)
            PlayMenu.SetActive(true);
    }
    public void SettingsClicked()
    {
        MainMenu.alpha = 0.5f;
        MainMenu.interactable = false;
        if (!SettingsMenu.activeInHierarchy)
            SettingsMenu.SetActive(true);
    }
    public void BackClicked()
    {
        MainMenu.alpha = 1f;
        MainMenu.interactable = true;
        if (SettingsMenu.activeInHierarchy)
            SettingsMenu.SetActive(false);
        if (PlayMenu.activeInHierarchy)
            PlayMenu.SetActive(false);
    }
    public void SinglePlayer()
    {
        LevelManager.Instance.LoadSceneAtIndex(1);
    }
    public void ExitClicked()
    {
        LevelManager.Instance.QuitGame();
    }
    public void SetSfxVolume(float _volume)
    {
        AudioManager.Instance.SetSfxVolume(_volume);
    }
    public void SetMusicVolume(float _volume)
    {
        AudioManager.Instance.SetMusicVolume(_volume);
    }
}
