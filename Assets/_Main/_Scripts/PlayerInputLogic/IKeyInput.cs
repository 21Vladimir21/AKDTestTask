using System;
using UnityEngine;

namespace _Main._Scripts.PlayerInputLogic
{
    public interface IKeyInput
    {
        event Action<KeyCode> KeyDown;
        event Action KeyUp;
    }
}