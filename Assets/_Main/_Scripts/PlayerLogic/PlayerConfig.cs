using UnityEngine;

namespace _Main._Scripts.PlayerLogic
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player/Create new player config", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField, Range(1, 10)] public float Speed { get; private set; }
        [field: SerializeField, Range(1, 100)] public float CameraSensitivity { get; private set; }
    }
}