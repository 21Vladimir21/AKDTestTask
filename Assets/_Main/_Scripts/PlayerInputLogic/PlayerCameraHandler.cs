using UnityEngine;
using Zenject;

namespace _Main._Scripts.PlayerInputLogic
{
    public class PlayerCameraHandler : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField,Range(1,100)] private float cameraSensitivity;
        private IMouseInput _mouseInput;

        [Inject]
        public void Construct(IMouseInput mouseInput)
        {
            _mouseInput = mouseInput;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _mouseInput.MousePositionChanged += UpdateCameraRotation;
        }

        private void UpdateCameraRotation(Vector3 direction)
        {
            Vector3 cameraRotation = cameraTransform.eulerAngles;
            cameraRotation.x -= direction.y * cameraSensitivity * Time.deltaTime;
            cameraTransform.eulerAngles = cameraRotation;

            var playerYRotation = transform.rotation.eulerAngles.y;
            playerYRotation += direction.x * cameraSensitivity * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, playerYRotation, 0);
        }
    }
}