namespace Content.CodeBase.Infrastructure.Services
{
    public abstract class InputService : IInputService
    {
        public abstract bool IsJumpButtonPressed();

        public abstract float GetAxis();
    }
}
