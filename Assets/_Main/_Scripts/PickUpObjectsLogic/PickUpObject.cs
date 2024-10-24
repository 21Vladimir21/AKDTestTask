using UnityEngine;

namespace _Main._Scripts.PickUpObjectsLogic
{
    [RequireComponent(typeof(Rigidbody))]
    public class PickUpObject : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;

        public void PickUp() => rigidbody.isKinematic = true;

        public void PickDown() => rigidbody.isKinematic = false;

        private void OnValidate()
        {
            if (rigidbody == null) rigidbody = GetComponent<Rigidbody>();
        }
    }
}