using UnityEngine;
using Zenject;

namespace _Main._Scripts.PlayerInputLogic
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField,Range(1,10)] private float speed;
        
        private IKeyInput _keyInput;
        private Vector3 _moveDirection;

        [Inject]
        public void Construct(IKeyInput playerInput)
        {
            _keyInput = playerInput;
            _keyInput.KeyDown += Move;

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
            rigidbody.velocity = _moveDirection * speed;
        }
    }
}