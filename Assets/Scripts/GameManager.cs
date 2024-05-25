using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Niveles;
    public GameObject Options;
    public GameObject volumeOptions;


    private void Start()
    {
        Time.timeScale = 1;
    }
    public void AppearOptions()
    {
        Options.SetActive(true);
        Time.timeScale = 0;
    }

    public void DissapearOptions()
    {
        Options.SetActive(false);
        Time.timeScale = 1;
    }

    public void FirstLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Nivel1");
    }

    public void SecondLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Nivel2");
    }

    public void AppearVolumeOptions()
    {
        Options.SetActive(false);
        volumeOptions.SetActive(true);
        Time.timeScale = 0;
    }
    public void DissappearVolumeOptions()
    {
        volumeOptions.SetActive(false);
        Options.SetActive(true);
        Time.timeScale = 0;
    }
    public void ReturnToMainMenú()
    {
        SceneManager.LoadScene("InicialScene");
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
