using System;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceFx;
    [SerializeField] AudioSource audioSourceMusic;
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
                audioSourceFx.PlayOneShot(sound.audioClip);
                break;
            case SoundType.BGMusic:
                audioSourceMusic.clip = sound.audioClip;
                audioSourceMusic.Play();
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
    public float GetMusicVolume()
    {
        return audioSourceMusic.volume;
    }
    public void SetMusicVolume(float _volume)
    {
        audioSourceMusic.volume = _volume;
    }
}
public enum SoundType
{
    Button, BGMusic
}
[Serializable]
public class Sound
{
    public SoundType soundType;
    public AudioClip audioClip;
}
