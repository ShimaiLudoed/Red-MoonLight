using Player;
using System;
using UnityEngine;

namespace Core
{
  public class BootStrapper : MonoBehaviour
  {
    private PlayerController _playerController;
    private PlayerModel _playerModel;
    [SerializeField] private InputListener inputListener;
    [SerializeField] private PlayerView playerView;
    [SerializeField] private float speed;

    private void Awake()
    {
      playerView.Construct(speed);
      _playerModel = new PlayerModel(playerView.Speed);
      _playerController = new PlayerController(_playerModel, playerView);
      inputListener.Construct(_playerController);
    }
  }
}