using UnityEngine;

namespace Content.CodeBase.Components
{
    public class PlayerMovement : BaseMovement
    {
        [SerializeField] private float _jumpSidePower = 1;

        private bool _isFalled;

        private void Update()
        {
            if (_isFalled) return;

            float jumpSide = inputService.GetAxis();

            if (Mathf.Abs(jumpSide) > 0)
            {
                JumpSide(jumpSide);
            }
            else if (inputService.IsJumpButtonPressed())
            {
                JumpForward();

                platformsFactory.SwapPlatforms();
            }
        }

        private void JumpForward()
        {
            nextPos += platformsFactory.JumpVector;
            Jump(nextPos);
        }

        private void JumpSide(float jumpSide)
        {
            nextPos += jumpSide * Vector3.right * _jumpSidePower;

            if (platformsFactory.PlatformSize.x / 2 < Mathf.Abs(nextPos.x))
            {
                Fall();
            }
            else
            {
                Jump(nextPos, 2);
            }
        }

        protected override void Fall()
        {
            _isFalled = true;

            Jump(nextPos + Vector3.down * 20, 15, 1f, base.Fall);
        }
    }
}