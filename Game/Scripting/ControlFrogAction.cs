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
            Frog racket = (Frog)cast.GetFirstActor(Constants.FROG_GROUP);
            if (_keyboardService.IsKeyDown(Constants.LEFT))
            {
                racket.JumpLeft();
            }
            else if (_keyboardService.IsKeyDown(Constants.RIGHT))
            {
                racket.JumpRight();
            }
            else if (_keyboardService.IsKeyDown(Constants.UP))
            {
                racket.JumpUp();
            }
            else if (_keyboardService.IsKeyDown(Constants.DOWN))
            {
                racket.JumpDown();
            }
            else
            {
                racket.StopMoving();
            }
        }
    }
}