using Player;
using System;
using UnityEngine;

namespace Core
{
  public class InputListener : MonoBehaviour
  {
    private  PlayerController _playerController;

    public void Construct(PlayerController playerController)
    {
      _playerController = playerController;
    }

    private void Update()
    {
      if ( _playerController != null )
      {
        float horizontal;
        horizontal=Input.GetAxis("Horizontal");
        Vector2 vec = new Vector2(horizontal, 0).normalized;
        _playerController.Move(vec);
      }
    }
  }
}