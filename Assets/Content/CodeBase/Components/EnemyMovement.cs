using Content.CodeBase.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Content.CodeBase.Components
{
    public class EnemyMovement : BaseMovement
    {
        [SerializeField] private float _jumpPower = 2;
        [SerializeField] private float _jumpDuration = 0.8f;
        [SerializeField] private int _jumpStep = 1;

        [Inject] private IPlatformsManager _platformsManager;

        public override void Init()
        {
            base.Init();

            JumpForward();
        }

        private void JumpForward()
        {
            jumpForwardCount++;
            
            nextPos -= _platformsManager.GetPlatformStep() * _jumpStep;

            if (jumpForwardCount > _platformsManager.GetPlatforms().Count)
            {
                Fall();
            }
            else
            {
                Jump(nextPos, _jumpPower, _jumpDuration, JumpForward);
            }
        }
    }
}