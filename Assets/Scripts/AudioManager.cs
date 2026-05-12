using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgMusicSource;
    public AudioSource sfxSource;

    public AudioClip[] characterThemes;   // one per character
    public AudioClip happySound, sadSound, angrySound;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PlayCharacterTheme(int index)
    {
        bgMusicSource.clip = characterThemes[index];
        bgMusicSource.Play();
    }

    public void PlayMoodSound(string mood)
    {
        AudioClip clip = mood switch
        {
            "Happy" => happySound,
            "Sad" => sadSound,
            "Angry" => angrySound,
            _ => null
        };
        if (clip) sfxSource.PlayOneShot(clip);
    }

    public void SetVolume(float value)
    {
        bgMusicSource.volume = value;
        sfxSource.volume = value;
    }

    public void ToggleMute()
    {
        bgMusicSource.mute = !bgMusicSource.mute;
        sfxSource.mute = !sfxSource.mute;
    }
}