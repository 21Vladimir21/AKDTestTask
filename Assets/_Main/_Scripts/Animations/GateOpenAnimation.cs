using DG.Tweening;
using UnityEngine;

namespace _Main._Scripts.Animations
{
    public class GateOpenAnimation : MonoBehaviour
    {
        [SerializeField] private float height;
        [SerializeField,Range(0,10f)] private float openDuration;

        private void Start() => OpenGate();

        private void OpenGate() => transform.DOLocalMoveY(height, openDuration);
    }
}