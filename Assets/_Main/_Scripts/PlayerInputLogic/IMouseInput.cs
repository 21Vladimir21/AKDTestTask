using System;
using UnityEngine;

namespace _Main._Scripts.PlayerInputLogic
{
    public interface IMouseInput
    {
        event Action ClickDown;
        event Action<Vector3> MousePositionChanged;
    }
}