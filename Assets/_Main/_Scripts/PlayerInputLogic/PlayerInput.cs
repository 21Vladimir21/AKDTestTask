using System;
using UnityEngine;
using Zenject;

namespace _Main._Scripts.PlayerInputLogic
{
    public class PlayerInput : IFixedTickable, ITickable, IKeyInput, IMouseInput
    {
        public event Action<KeyCode> KeyDown;
        public event Action KeyUp;
        public event Action ClickDown;
        public event Action<Vector3> MousePositionChanged;

        private const int LeftMouseButton = 0;

        private bool _isSwiping;

        private Vector3 _previousMousePosition;
        private KeyCode[] _inputKeys = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };

        public void FixedTick() => CheckKeyDown();

        public void Tick()
        {
            CheckKeyUp();
            MousePositionHandler();
            OnClickDown();
        }

        private void CheckKeyDown()
        {
            foreach (var key in _inputKeys)
                if (Input.GetKey(key))
                    KeyDown?.Invoke(key);
        }

        private void CheckKeyUp()
        {
            foreach (var key in _inputKeys)
                if (Input.GetKeyUp(key))
                    KeyUp?.Invoke();
        }

        private void MousePositionHandler()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            if (mouseX != 0 || mouseY != 0)
            {
                Vector3 direction = new Vector3(mouseX, mouseY, 0);
                MousePositionChanged?.Invoke(direction);
            }
        }

        private void OnClickDown()
        {
            if (Input.GetMouseButtonDown(LeftMouseButton)) ClickDown?.Invoke();
        }
    }
}