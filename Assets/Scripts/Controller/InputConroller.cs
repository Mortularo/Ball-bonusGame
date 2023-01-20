using UnityEngine;

namespace MF
{
    public class InputConroller : IExecute
    {
        private readonly Unit _player;
        private float _horizontal, _vertical;

        public InputConroller(Unit player)
        {
            _player = player;
        }
        public void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            _player.Move(_horizontal, 0, _vertical);
        }
    }
}
