using System;
using UnityEngine;
using Zenject;

namespace _Main._Scripts.PlayerInputLogic
{
    public class PlayerInput : IFixedTickable, ITickable, IKeyInput, IMouseInput
    {
        public event Action<KeyCode> KeyDown;

        public event Action ClickDown;
        public event Action<Vector3> MousePositionChanged;


        private const int LeftMouseButton = 0;

        private bool _isSwiping;
        private Vector3 _previousMousePosition;

        public void FixedTick()
        {
            if (Input.GetKey(KeyCode.W))
                KeyDown?.Invoke(KeyCode.W);
            if (Input.GetKey(KeyCode.A))
                KeyDown?.Invoke(KeyCode.A);
            if (Input.GetKey(KeyCode.S))
                KeyDown?.Invoke(KeyCode.S);
            if (Input.GetKey(KeyCode.D))
                KeyDown?.Invoke(KeyCode.D);
        }

        public void Tick()
        {
            MousePositionHandler();
            OnClickDown();
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