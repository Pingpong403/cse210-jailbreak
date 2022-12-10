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
        /// from one side of the screen to the other when it reaches the maximum x and y 
        /// values.
        /// </summary>
        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> obstacles = cast.GetActors(Constants.OBSTACLE_GROUP);
            // int x = position.GetX();

            foreach (Obstacle obstacle in obstacles)
            {
                int maxX = Constants.SCREEN_WIDTH;
                int maxY = Constants.SCREEN_HEIGHT;
                
                Body body = obstacle.GetBody();
                string type = obstacle.GetObstacleType();
                Point position = body.GetPosition();
                Point velocity = body.GetVelocity();
                int obstacle_width = 0;

                if (type == "log")
                {
                    obstacle_width = Constants.LOG_WIDTH;
                } else if (type == "car" || type == "policeCar")
                {
                    obstacle_width = Constants.CAR_WIDTH;
                } else if (type == "tricycle")
                {
                    obstacle_width = Constants.TRICYCLE_WIDTH;
                } else
                {}
            

                int x = ((position.GetX() + velocity.GetX()) + maxX) % maxX - obstacle_width;
                int y = ((position.GetY() + velocity.GetY()) + maxY) % maxY;
                position = new Point(x, y);

                // position = position.Add(velocity);
                body.SetPosition(position);
            }

        
        }
    }
}