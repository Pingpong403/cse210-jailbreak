using Unit06.Game.Casting;
using Unit06.Game.Services;
using System.Collections.Generic;
using System;

namespace Unit06.Game.Scripting
{
    public class MoveObstaclesAction : Action
    {
        
        public MoveObstaclesAction()
        {
        }

        /// <summary>
        /// Moves the actor to its next position according to its velocity. Will wrap the position 
        /// from one side of the screen to the other when it reaches the maximum x
        /// value.
        /// </summary>
        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> obstacles = cast.GetActors(Constants.OBSTACLE_GROUP);

            foreach (Obstacle obstacle in obstacles)
            {
                int maxX = Constants.SCREEN_WIDTH;
                int maxY = Constants.SCREEN_HEIGHT;
                
                Body body = obstacle.GetBody();
                Point position = body.GetPosition();
                Point velocity = body.GetVelocity();

                int x = position.GetX() + velocity.GetX();
                int y = position.GetY() + velocity.GetY();
                position = new Point(x, y);

                // WRAPPING
                // Left
                if (!obstacle.GetDirection())
                {
                    if (x <= -64)
                    {
                        x += Constants.SCREEN_WIDTH + 128;
                    }
                }
                // Right
                else
                {
                    if (x >= Constants.SCREEN_WIDTH)
                    {
                        x -= (Constants.SCREEN_WIDTH + 128);
                    }
                }

                body.SetPosition(new Point(x, y));
            }

        
        }
    }
}