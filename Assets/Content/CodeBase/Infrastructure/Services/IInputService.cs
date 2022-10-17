namespace Content.CodeBase.Infrastructure.Services
{
    public interface IInputService : IService
    {
        bool IsJumpButtonPressed();
        float GetAxis();
    }
}