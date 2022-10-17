using UnityEngine;
using UnityEngine.SceneManagement;

namespace Content.CodeBase.Components
{
    public class Player : Unit
    {
        [SerializeField] private OnTriggerWrapper _triggerWrapper;
        public override void Init()
        {
            base.Init();
            
            _triggerWrapper.Entered += OnTrigger;
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            _triggerWrapper.Entered -= OnTrigger;
        }

        protected override void Die()
        {
            base.Die();
            
            SceneManager.LoadScene(0);
        }
        
        private void OnTrigger(Collider collider) => Die();
    }
}