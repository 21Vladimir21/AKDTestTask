using _Main._Scripts.PlayerInputLogic;
using UnityEngine;
using Zenject;

namespace _Main._Scripts.PlayerLogic
{
    public class PlayerCameraHandler : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        private IMouseInput _mouseInput;
        private float _cameraSensitivity;

        [Inject]
        public void Construct(IMouseInput mouseInput, PlayerConfig playerConfig)
        {
            _cameraSensitivity = playerConfig.CameraSensitivity;
            _mouseInput = mouseInput;
            HideCursore();
            _mouseInput.MousePositionChanged += UpdateCameraRotation;
        }

        private static void HideCursore()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void UpdateCameraRotation(Vector3 direction)
        {
            Vector3 cameraRotation = cameraTransform.eulerAngles;
            cameraRotation.x -= direction.y * _cameraSensitivity * Time.deltaTime;
            cameraTransform.eulerAngles = cameraRotation;

            var playerYRotation = transform.rotation.eulerAngles.y;
            playerYRotation += direction.x * _cameraSensitivity * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, playerYRotation, 0);
        }
    }
}