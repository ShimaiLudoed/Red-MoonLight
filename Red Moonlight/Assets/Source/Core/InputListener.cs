using Player;
using System;
using UnityEngine;

namespace Core
{
  public class InputListener : MonoBehaviour
  {
    private PlayerController _playerController;

    //TODO собрать отдельный серивс для управления объектами для управления подписками (типа обсервер) 
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

      if (Input.GetKey(KeyCode.I))
      {
        _playerController.ShowInventory();
      }

      if (Input.GetKeyDown(KeyCode.E))
      {
        OnInteract.Invoke();
      }
      //Это не кринж
      //TODO можно переделать если надо 
    }
  }
}