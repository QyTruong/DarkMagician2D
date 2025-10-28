using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.mainMenuBackgroundMusic);
    }

    public void OnPlayButton()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonClickSFX);
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    public void OnCreditButton()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonClickSFX);
    }

    public void OnExitButton()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonClickSFX);
        Application.Quit();
    }
}
