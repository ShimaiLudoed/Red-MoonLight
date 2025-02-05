using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
  public class SceneChange : MonoBehaviour
  {
    public void StartGame()
    {
      SceneManager.LoadScene("Game");
    }
  }
}
