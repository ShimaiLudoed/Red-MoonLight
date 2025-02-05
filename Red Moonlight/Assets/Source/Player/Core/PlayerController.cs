using Vector2 = UnityEngine.Vector2;

namespace Player
{
    public class PlayerController
    {
        private readonly PlayerView _playerView;
        private readonly PlayerModel _playerModel;
        private readonly Inventory _inventory;

        public PlayerController(PlayerModel playerModel, PlayerView playerView, Inventory inventory)
        {
            _playerView = playerView;
            _playerModel = playerModel;
            _inventory = inventory;
        }

        public void Move(Vector2 direction)
        {
            _playerView.Move(_playerModel.Speed, direction);
        }

        public void ShowInventory()
        {
            _inventory.ShowInventory();
        }
        
    }
}
