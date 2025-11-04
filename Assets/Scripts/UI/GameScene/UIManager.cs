using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject endGameMenu;
    public TextMeshProUGUI txtEndGame;
    public List<Entity> entities;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.gameSceneBackgroundMusic);
    }

    private void Update()
    {
        if (!entities[0].isActive)
        {
            endGameMenu.SetActive(true);
            txtEndGame.text = "You lose!!!";
        }
        else if (!entities[1].isActive)
        {
            endGameMenu.SetActive(true);
            txtEndGame.text = "You win!!!";
        }
    }

    public void OnGameRestartPress()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonClickSFX);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnGameResumePress()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonClickSFX);
        pauseMenu.SetActive(false);

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
        pauseMenu.SetActive(true);

        Time.timeScale = 0f;

        OnableActities(false);
    }

    private void OnableActities(bool isEnable)
    {
        foreach (var e in entities)
            e.GetComponent<Entity>().enabled = isEnable;
    }
}
