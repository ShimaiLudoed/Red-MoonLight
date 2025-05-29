using Player;
using System;
using UnityEngine;

namespace Core
{
  public class InputListener : MonoBehaviour
  {
    private PlayerController _playerController;
    
    public static event Action OnInteract;

    public void Construct(PlayerController playerController)
    {
      _playerController = playerController;
    }

    private void FixedUpdate()
    {
      if (_playerController != null)
      {
        float horizontal;
        horizontal = Input.GetAxis("Horizontal");
        Vector2 vec = new Vector2(horizontal, 0).normalized;
        _playerController.Move(vec);
      }
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.I))
      {
        _playerController.ShowInventory();
      }

      if (Input.GetKeyDown(KeyCode.Q))
      {
        _playerController.ShowQuestBook();
      }

      if (Input.GetKeyDown(KeyCode.R))
      {
        _playerController.ShowPersonView();
      }
      if (Input.GetKeyDown(KeyCode.E))
      {
        OnInteract?.Invoke();
      }
      //TODO можно переделать если надо 
    }
  }
}