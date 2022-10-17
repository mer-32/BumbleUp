using System;
using UnityEngine;

namespace Content.CodeBase.Components
{
    public class OnTriggerWrapper : MonoBehaviour
    {
        public Action<Collider> Entered { get; set; }
        public Action<Collider> Exited { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            Entered?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            Exited?.Invoke(other);
        }
    }
}
