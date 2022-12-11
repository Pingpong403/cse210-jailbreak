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
            List<Actor> tiles = cast.GetActors(Constants.TILE_GROUP);
            Sound bounceSound = new Sound(Constants.BOUNCE_SOUND);
            Sound overSound = new Sound(Constants.OVER_SOUND);

            foreach (Actor actor in obstacles)
            {
                Obstacle obstacle = (Obstacle)actor;
                Body obstacleBody = obstacle.GetBody();
                string obstacleType = obstacle.GetObstacleType();
                Body frogBody = frog.GetBody();

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
                }
            }
            foreach (Actor actor in tiles)
            {
                Tile tile = (Tile)actor;
                Body tileBody = tile.GetBody();
                string tileType = tile.GetTileType();
                Body frogBody = frog.GetBody();

                if (tileType == "ww")
                {
                    if (!frog.IsJumping())
                    {
                        if (_physicsService.HasCollided(tileBody, frogBody))
                        {
                            bool logCollided = false;
                            foreach (Actor preObstacle in obstacles)
                            {
                                Obstacle obstacle = (Obstacle)preObstacle;
                                if (obstacle.GetObstacleType() == "log")
                                {
                                    Body logBody = obstacle.GetBody();
                                    if (_physicsService.HasCollided(frogBody, logBody))
                                    {
                                        logCollided = true;
                                    }
                                }
                            }
                            if (!logCollided)
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
                        }
                    }
                }
            }
        }
    }
}