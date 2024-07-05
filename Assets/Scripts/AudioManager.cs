using UnityEngine;

public enum SoundEffect
{
    Button_OnMouse,
    Botton_Click,
}

public enum BGM
{
    AllInOne,
}

public class AudioManager : Singleton<AudioManager>
{
    [Header("Sound Effects")]
    public AudioSource[] sfx;
    [Header("BGM")]
    public AudioSource[] bgm;
    public void PlaySFX(SoundEffect soundEffectenum)
    {
        if ((int)soundEffectenum < sfx.Length)
        {
            sfx[(int)soundEffectenum].Play();
        }
    }
    public void PlayBGM(BGM backgroundMusicenum)
    {
        if ((int)backgroundMusicenum < bgm.Length)
        {
            bgm[(int)backgroundMusicenum].Play();
        }
    }
}
