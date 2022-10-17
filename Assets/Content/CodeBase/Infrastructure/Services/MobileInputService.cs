using UnityEngine;

namespace Content.CodeBase.Infrastructure.Services
{
    public class MobileInputService : InputService
    {
        private const int SWIPE_MIN_DISTANCE = 10;
        
        private Vector2 _firstPressPos;
        private Vector2 _secondPressPos;
        private Vector2 _currentSwipe;

        public override bool IsJumpButtonPressed() => Input.GetMouseButtonUp(0);

        public override float GetAxis()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _firstPressPos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _secondPressPos = Input.mousePosition;
                _currentSwipe = new Vector2(_secondPressPos.x - _firstPressPos.x, _secondPressPos.y - _firstPressPos.y);

                if ((_secondPressPos - _firstPressPos).sqrMagnitude > SWIPE_MIN_DISTANCE)
                {
                    if (Mathf.Abs(_currentSwipe.x) > Mathf.Abs(_currentSwipe.y))
                    {
                        return _currentSwipe.x > 0 ? 1 : -1;
                    }
                }
            }

            return 0;
        }
    }
}