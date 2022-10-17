using UnityEngine;

namespace Content.CodeBase.Components
{
    public class EnemyMovement : BaseMovement
    {
        [SerializeField] private float _jumpPower = 2;
        [SerializeField] private float _jumpDuration = 0.8f;
        [SerializeField] private int _jumpStep = 1;

        public override void Init()
        {
            base.Init();

            JumpForward();
        }

        private void JumpForward()
        {
            jumpForwardCount++;
            nextPos -= platformsFactory.JumpVector * _jumpStep;

            if (jumpForwardCount > platformsFactory.Platforms.Count)
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