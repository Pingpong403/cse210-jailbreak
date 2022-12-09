using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class ControlFrogAction : Action
    {
        private KeyboardService _keyboardService;

        public ControlFrogAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Frog frog = (Frog)cast.GetFirstActor(Constants.FROG_GROUP);

            if (!frog.IsJumping())
            {
                if (_keyboardService.IsKeyPressed(Constants.LEFT))
                {
                    frog.JumpLeft();
                }
                else if (_keyboardService.IsKeyPressed(Constants.RIGHT))
                {
                    frog.JumpRight();
                }
                else if (_keyboardService.IsKeyPressed(Constants.UP))
                {
                    frog.JumpUp();
                }
                else if (_keyboardService.IsKeyPressed(Constants.DOWN))
                {
                    frog.JumpDown();
                }
            }
        }
    }
}