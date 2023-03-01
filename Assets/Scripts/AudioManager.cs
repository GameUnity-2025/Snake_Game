using System;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceMenu;
    [SerializeField] AudioSource audioSourceFx;
    public Sound[] sounds;
    private static AudioManager instance = null;
    public static AudioManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void PlaySound(SoundType soundType)
    {
        Sound sound = Array.Find(sounds, item => item.soundType == soundType);
        switch (soundType)
        {
            case SoundType.Button:
                audioSourceMenu.PlayOneShot(sound.audioClip);
                break;
            case SoundType.Food:
                audioSourceFx.PlayOneShot(sound.audioClip);
                break;
            case SoundType.GameOver:
                audioSourceFx.PlayOneShot(sound.audioClip);
                break;
        }
    }
    public float GetSfxVolume()
    {
        return audioSourceFx.volume;
    }
    public void SetSfxVolume(float _volume)
    {
        audioSourceFx.volume = _volume;
    }
    public float GetMenuVolume()
    {
        return audioSourceMenu.volume;
    }
    public void SetMenuVolume(float _volume)
    {
        audioSourceMenu.volume = _volume;
    }
}
public enum SoundType
{
    Button, Food, GameOver
}
[Serializable]
public class Sound
{
    public SoundType soundType;
    public AudioClip audioClip;
}
