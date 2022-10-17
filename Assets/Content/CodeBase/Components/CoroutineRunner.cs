using System.Collections;
using UnityEngine;

namespace Content.CodeBase.Components
{
    public class CoroutineRunner : MonoBehaviour
    {
        public void StartRoutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}

