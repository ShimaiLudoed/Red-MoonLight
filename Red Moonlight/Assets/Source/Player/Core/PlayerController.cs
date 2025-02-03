using System.Numerics;
using Vector2 = UnityEngine.Vector2;

namespace Player
{
    public class PlayerController
    {
        private readonly PlayerView _playerView;
        private readonly TriggerDetector _triggerDetector;
        private readonly PlayerModel _playerModel;

        public PlayerController(PlayerModel playerModel, PlayerView playerView /*TriggerDetector triggerDetector*/)
        {
            _playerView = playerView;
           // _triggerDetector = triggerDetector;
            _playerModel = playerModel;
        }

        public void Move(Vector2 direction)
        {
            _playerView.Move(_playerModel.Speed, direction);
        }
        
    }
}
