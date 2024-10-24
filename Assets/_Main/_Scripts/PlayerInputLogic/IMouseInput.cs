using System;
using UnityEngine;

namespace _Main._Scripts.PlayerInputLogic
{
    public interface IMouseInput
    {
        event Action<Vector3> ClickDown;
        event Action<Vector3> ClickUp;
        event Action<Vector3> Drag;
        event Action<Vector3> MousePositionChanged;
    }
}