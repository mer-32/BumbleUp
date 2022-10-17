using UnityEngine;

namespace Content.CodeBase.Components
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] protected BaseMovement baseMovement;

        public virtual void Init()
        {
            baseMovement.Falled += Die;
            
            baseMovement.Init();
        }

        protected virtual void OnDestroy() => baseMovement.Falled -= Die;
        
        protected virtual void Die() => Destroy(gameObject);
    }
}