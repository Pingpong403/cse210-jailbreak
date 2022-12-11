// CHANGE TO COLLIDE OBSTACLES ACTION

using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CollideObstaclesAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollideObstaclesAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Frog frog = (Frog)cast.GetFirstActor(Constants.FROG_GROUP);
            List<Actor> obstacles = cast.GetActors(Constants.OBSTACLE_GROUP);
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            
            foreach (Actor actor in obstacles)
            {
                Obstacle obstacle = (Obstacle)actor;
                Body obstacleBody = obstacle.GetBody();
                string obstacleType = obstacle.GetObstacleType();
                Body frogBody = frog.GetBody();
                Sound bounceSound = new Sound(Constants.BOUNCE_SOUND);
                Sound overSound = new Sound(Constants.OVER_SOUND);

                if (_physicsService.HasCollided(obstacleBody, frogBody))
                {
                    if (obstacleType != "log")
                    {
                        _audioService.PlaySound(bounceSound);
                        stats.RemoveLife();

                        if (stats.GetLives() > 0)
                        {
                            callback.OnNext(Constants.TRY_AGAIN);
                        }
                        else
                        {
                            callback.OnNext(Constants.GAME_OVER);
                            _audioService.PlaySound(overSound);
                        }
                    }
                    else if (obstacleType == "log")
                    {

                    }
                }
            }
        }
    }
}