using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseUI;
    public List<Entity> entities;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.gameSceneBackgroundMusic);
    }

    public void OnGameRestartPress()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonClickSFX);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnGameResumePress()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonClickSFX);
        pauseUI.SetActive(false);

        OnableActities(true);

        Time.timeScale = 1f;
    }

    public void OnGameExitPress()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonClickSFX);
        SceneManager.LoadScene("MainMenuScene");
    }

    public void OnGamePausePress()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonClickSFX);
        pauseUI.SetActive(true);

        Time.timeScale = 0f;

        OnableActities(false);
    }

    private void OnableActities(bool isEnable)
    {
        foreach (var e in entities)
            e.GetComponent<Entity>().enabled = isEnable;
    }
}
