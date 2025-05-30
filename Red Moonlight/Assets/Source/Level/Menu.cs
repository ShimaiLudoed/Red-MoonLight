using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
[SerializeField] private GameObject pauseMenuUI; 
    [SerializeField] private Button resumeButton; 
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitToMenuButton;
    [SerializeField] private Button exitGameButton;
    [SerializeField] private GameObject SettingsPanel;
    private bool isPaused = false;
    private void Start()
    {

        pauseMenuUI.SetActive(false);
        resumeButton.onClick.AddListener(Resume);
        settingsButton.onClick.AddListener(OpenSettings);
        quitToMenuButton.onClick.AddListener(QuitToMenu);
        exitGameButton.onClick.AddListener(ExitGame);
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    private void Pause()
    {
        pauseMenuUI.SetActive(true); 
        Time.timeScale = 0f; 
        isPaused = true;
    }
    private void Resume()
    {
        pauseMenuUI.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false;
    }
    private void OpenSettings()
    {
        SettingsPanel.SetActive(true);
    }
    private void QuitToMenu()
    {
        isPaused = false;
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
