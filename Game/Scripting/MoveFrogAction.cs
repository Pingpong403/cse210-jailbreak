using Unit06.Game.Casting;
using System.Collections.Generic;
using Unit06.Game.Services;

namespace Unit06.Game.Scripting
{
    public class MoveFrogAction : Action
    {
        PhysicsService _physicsService;
        public MoveFrogAction(PhysicsService physicsService)
        {
            this._physicsService = physicsService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Frog frog = (Frog)cast.GetFirstActor(Constants.FROG_GROUP);
            Body frogBody = frog.GetBody();
            Point position = frogBody.GetPosition();
            Point velocity = frogBody.GetVelocity();
            int x = position.GetX();
            int y = position.GetY();

            position = position.Add(velocity);

            List<Actor> obstacles = cast.GetActors(Constants.OBSTACLE_GROUP);
            foreach (Actor actor in obstacles)
            {
                Obstacle obstacle = (Obstacle)actor;
                Body obstacleBody = obstacle.GetBody();
                if (obstacle.GetObstacleType() == "log" && !frog.IsJumping())
                {
                    if (_physicsService.HasCollided(frogBody, obstacleBody))
                    {
                        position = position.Add(obstacleBody.GetVelocity());
                    }
                }
            }

            frogBody.SetPosition(position);       
        }
    }
}