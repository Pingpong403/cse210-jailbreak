using Unit06.Game.Casting;
using Unit06.Game.Services;
using System;


namespace Unit06.Game.Scripting
{
    public class CollideBordersAction : Action
    {
        
        public CollideBordersAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Frog frog = (Frog)cast.GetFirstActor(Constants.FROG_GROUP);
            Body body = frog.GetBody();
            Point position = body.GetPosition();
            int x = position.GetX();
            int y = position.GetY();
            int leftEdge = x;
            int rightEdge = x + Constants.FROG_WIDTH;
            int topEdge = y;
            int bottomEdge = y + Constants.FROG_SIT_HEIGHT;

            // Left
            if (leftEdge <= Constants.TILE_SIZE / 2)
            {
                frog.ControlJump("left", false);
            }
            else
            {
                frog.ControlJump("left", true);
            }
            // Right
            if (rightEdge >= Constants.SCREEN_WIDTH - Constants.TILE_SIZE / 2)
            {
                frog.ControlJump("right", false);
            }
            else
            {
                frog.ControlJump("right", true);
            }
            // Top
            if (topEdge <= Constants.TILE_SIZE / 2)
            {
                if (x > Constants.CENTER_X + Constants.TILE_SIZE / 2 || x < Constants.CENTER_X - Constants.TILE_SIZE / 2)
                {
                    frog.ControlJump("up", false);
                }
                else
                {
                    frog.ControlJump("up", true);
                }
            }
            else
            {
                frog.ControlJump("up", true);
            }
            // Bottom
            if (bottomEdge >= Constants.SCREEN_HEIGHT - Constants.TILE_SIZE / 2)
            {
                frog.ControlJump("down", false);
            }
            else
            {
                frog.ControlJump("down", true);
            }
        }
    }
}