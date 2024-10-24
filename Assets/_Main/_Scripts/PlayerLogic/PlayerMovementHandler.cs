using _Main._Scripts.PlayerInputLogic;
using UnityEngine;
using Zenject;

namespace _Main._Scripts.PlayerLogic
{
    public class PlayerMovementHandler : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;

        private IKeyInput _keyInput;
        private Vector3 _moveDirection;

        private float _speed;

        [Inject]
        public void Construct(IKeyInput keyInput, PlayerConfig playerConfig)
        {
            _speed = playerConfig.Speed;
            _keyInput = keyInput;
            _keyInput.KeyDown += Move;
            _keyInput.KeyUp += StopMove;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


        private void Move(KeyCode keyCode)
        {
            switch (keyCode)
            {
                case KeyCode.W:
                    _moveDirection += transform.forward;
                    break;
                case KeyCode.A:
                    _moveDirection -= transform.right;
                    break;
                case KeyCode.S:
                    _moveDirection -= transform.forward;
                    break;
                case KeyCode.D:
                    _moveDirection += transform.right;
                    break;
            }

            _moveDirection.Normalize();
            rigidbody.velocity = _moveDirection * _speed;
        }

        private void StopMove() => rigidbody.velocity = Vector3.zero;
    }
}