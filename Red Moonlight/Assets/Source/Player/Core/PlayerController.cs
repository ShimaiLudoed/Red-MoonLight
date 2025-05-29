using Vector2 = UnityEngine.Vector2;

namespace Player
{
    public class PlayerController
    {
        private readonly PlayerView _playerView;
        private readonly PlayerModel _playerModel;
        private readonly NormalInventory _inventory;
        private readonly NormalQuestBook _questBook;
        private readonly NormanPersonView _normanPersonView;

        public PlayerController(PlayerModel playerModel, PlayerView playerView, NormalInventory inventory, NormalQuestBook questBook, NormanPersonView personView)
        {
            _playerView = playerView;
            _playerModel = playerModel;
            _inventory = inventory;
            _questBook = questBook;
            _normanPersonView = personView;
        }

        public void Move(Vector2 direction)
        {
            _playerView.Move(_playerModel.Speed, direction);
        }

        public void ShowPersonView()
        {
            _normanPersonView.Show();
        }
        public void ShowInventory()
        {
            _inventory.Show();
        }

        public void ShowQuestBook()
        {
            _questBook.Show();
        }
    }
}
