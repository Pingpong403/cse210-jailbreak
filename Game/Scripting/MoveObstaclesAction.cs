using Unit06.Game.Casting;
using System.Collections.Generic;

namespace Unit06.Game.Scripting
{
    public class MoveObstaclesAction : Action
    {
        public MoveObstaclesAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> obstacles = cast.GetActors(Constants.OBSTACLE_GROUP);
            // int x = position.GetX();

            foreach (Obstacle obstacle in obstacles)
            {
                Body body = obstacle.GetBody();
                Point position = body.GetPosition();
                Point velocity = body.GetVelocity();
                position = position.Add(velocity);
                body.SetPosition(position);
            }
        }
    }
}