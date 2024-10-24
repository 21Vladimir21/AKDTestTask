using _Main._Scripts.PickUpObjectsLogic;
using _Main._Scripts.PlayerInputLogic;
using UnityEngine;
using Zenject;

namespace _Main._Scripts.PlayerLogic
{
    public class DragHandler : MonoBehaviour
    {
        [SerializeField] private Transform pickUpPoint;
        [SerializeField] private Transform rayPoint;

        private IMouseInput _mouseInput;
        private PickUpObject _currentPickUpObject;

        [Inject]
        private void Construct(IMouseInput mouseInput)
        {
            _mouseInput = mouseInput;
            _mouseInput.ClickDown += TryPickUpObject;
        }

        private void TryPickUpObject()
        {
            var hit = CastRay();
            if (_currentPickUpObject == null && hit.collider.TryGetComponent(out PickUpObject pickUpObject))
            {
                _currentPickUpObject = pickUpObject;
                pickUpObject.PickUp();
                pickUpObject.transform.position = pickUpPoint.position;
                pickUpObject.transform.SetParent(pickUpPoint);
            }
            else if (_currentPickUpObject != null)
            {
                _currentPickUpObject.PickDown();
                _currentPickUpObject.transform.SetParent(null);
                _currentPickUpObject = null;
            }
        }

        private RaycastHit CastRay()
        {
            var ray = new Ray(rayPoint.position, rayPoint.forward);
            if (Physics.Raycast(ray, out RaycastHit hit))
                return hit;

            return default;
        }
    }
}