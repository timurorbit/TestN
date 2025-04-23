namespace MageDefence
{
    public class PlayerInput : PlayerInputUnityBase
    {
        public override void HandleInput()
        {
            HandleMovementInput();
            HandleSpellChangeInput();
            HandleSpellInput();
        }
    }  
}
