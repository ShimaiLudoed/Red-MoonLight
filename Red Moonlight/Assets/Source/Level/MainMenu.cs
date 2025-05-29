using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
  [SerializeField] private Button continueButton;
  [SerializeField] private Button newGameButton;
  [SerializeField] private Button settingsButton;
  [SerializeField] private Button settingsButtonOff;
  [SerializeField] private Button quitButton;
  [SerializeField] private GameObject settingsPanel;

  private void Start()
  {
    continueButton.onClick.AddListener(OnContinue);
    newGameButton.onClick.AddListener(OnNewGame);
    settingsButton.onClick.AddListener(OnSettings);
    settingsButtonOff.onClick.AddListener(OffSettings);
    quitButton.onClick.AddListener(OnQuit);
  }

  private void OnContinue()
  {
    LoadGameScene();
  }

  private void OnNewGame()
  {
    SceneManager.LoadScene("Game");
  }

  private void OnSettings()
  {
    settingsPanel.gameObject.SetActive(true);
  }

  private void OffSettings()
  {
    settingsPanel.gameObject.SetActive(false);
  }

  private void OnQuit()
  {
    Application.Quit();
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
    #endif
  }

  private void LoadGameScene()
  {
    SceneManager.LoadScene("Game");
  }
}
