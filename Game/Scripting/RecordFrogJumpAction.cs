using Unit06.Game.Casting;
using System;


namespace Unit06.Game.Scripting
{
    public class RecordFrogJumpAction : Action
    {
        private int _currentJump;
        private int _frogJumpDistance;

        public RecordFrogJumpAction()
        {
            _currentJump = 0;
            _frogJumpDistance = Constants.FROG_JUMP_DISTANCE;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Frog frog = (Frog)cast.GetFirstActor(Constants.FROG_GROUP);
            Point frogLastJump = frog.GetLastJumpPosition();
            Point frogCurrentPosition = frog.GetBody().GetPosition();

            // Up
            if (frog.GetDirection() == 0)
            {
                _currentJump = (frogCurrentPosition.GetY() - frogLastJump.GetY()) * -1;
                if (frogLastJump.GetY() != frogCurrentPosition.GetY())
                {
                    if (_currentJump >= _frogJumpDistance)
                    {
                        frog.StopMoving();
                        _currentJump = 0;
                    }
                }
            }
            // Right
            else if (frog.GetDirection() == 1)
            {
                _currentJump = frogCurrentPosition.GetX() - frogLastJump.GetX();
                if (frogLastJump.GetX() != frogCurrentPosition.GetX())
                {
                    if (_currentJump >= _frogJumpDistance)
                    {
                        frog.StopMoving();
                        _currentJump = 0;
                    }
                }
            }
            // Down
            else if (frog.GetDirection() == 2)
            {
                _currentJump = frogCurrentPosition.GetY() - frogLastJump.GetY();
                if (frogLastJump.GetY() != frogCurrentPosition.GetY())
                {
                    if (_currentJump >= _frogJumpDistance)
                    {
                        frog.StopMoving();
                        _currentJump = 0;
                    }
                }
            }
            // Left
            else if (frog.GetDirection() == 3)
            {
                _currentJump = (frogCurrentPosition.GetX() - frogLastJump.GetX()) * -1;
                if (frogLastJump.GetX() != frogCurrentPosition.GetX())
                {
                    if (_currentJump >= _frogJumpDistance)
                    {
                        frog.StopMoving();
                        _currentJump = 0;
                    }
                }
            }
        }
    }
}