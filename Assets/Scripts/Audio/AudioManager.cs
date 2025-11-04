using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get => instance; }

    [Header("---Audio Sources---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("---Audio Clip---")]
    [Header("---Gameplay---")]
    public AudioClip mainMenuBackgroundMusic;
    public AudioClip gameSceneBackgroundMusic;
    public AudioClip buttonClickSFX;
    [Header("---Player---")]
    public AudioClip playerJumpSFX;
    public AudioClip playerHurtSFX;
    public AudioClip playerShootSFX;
    public AudioClip playerDashSFX;

    private AudioManager()
    {
        
    }

    private void Awake()
    {
        Debug.Log("hello");
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

    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        if (clip.Equals(gameSceneBackgroundMusic))
            musicSource.volume = 0.5f;
        else
            musicSource.volume = 1f;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip.Equals(buttonClickSFX))
            sfxSource.volume = 0.15f;
        else
            sfxSource.volume = 1f;
        sfxSource.PlayOneShot(clip);
    }

}
