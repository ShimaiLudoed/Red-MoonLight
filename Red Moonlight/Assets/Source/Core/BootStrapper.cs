using Player;
using System;
using UnityEngine;

namespace Core
{
  public class BootStrapper : MonoBehaviour
  {
    [SerializeField] private NormalQuestBook questBook;
    [SerializeField] private NormalInventory inventory;
    [SerializeField] private NormanPersonView personView; 
    private PlayerController _playerController;
    private PlayerModel _playerModel;
    [SerializeField] private InputListener inputListener;
    [SerializeField] private PlayerView playerView;
    [SerializeField] private float speed;
    

    private void Awake()
    {
      playerView.Construct(speed);
      _playerModel = new PlayerModel(playerView.Speed);
      _playerController = new PlayerController(_playerModel, playerView, inventory, questBook, personView);
      inputListener.Construct(_playerController);
    }
  }
}