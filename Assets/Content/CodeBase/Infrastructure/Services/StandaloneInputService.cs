using UnityEngine;

namespace Content.CodeBase.Infrastructure.Services
{
    public class StandaloneInputService : InputService
    {
        private const string AxisName = "Horizontal";

        public override bool IsJumpButtonPressed() => Input.GetKeyUp(KeyCode.Space);

        public override float GetAxis()
        {
            if (Input.GetButtonDown(AxisName))
            {
                return Input.GetAxisRaw(AxisName);
            }

            return 0;
        }
    }
}