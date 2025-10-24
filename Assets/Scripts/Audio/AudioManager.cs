using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get => instance; }

    [Header("---Audio Sources---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("---Audio Clip---")]
    public AudioClip mainMenuBackgroundMusic;
    public AudioClip gameSceneBackgroundMusic;
    public AudioClip buttonClickSFX;
    public AudioClip playerJumpSFX;
    public AudioClip playerHurtSFX;

    private AudioManager()
    {

    }

    private void Awake()
    {
        if (instance == null)
        {
            AudioManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = mainMenuBackgroundMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
