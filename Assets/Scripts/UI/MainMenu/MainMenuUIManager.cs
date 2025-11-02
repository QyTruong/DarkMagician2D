using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    public GameObject creditPanel; 

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
        creditPanel.SetActive(true);
    }

    public void OnExitButton()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonClickSFX);
        Application.Quit();
    }

    public void OnBackToMenuButton()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonClickSFX);
        creditPanel.SetActive(false);
    }
}
