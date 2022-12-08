using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawObstaclesAction : Action
    {
        private VideoService _videoService;
        
        public DrawObstaclesAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> obstacles = cast.GetActors(Constants.OBSTACLE_GROUP);
            foreach (Actor actor in obstacles)
            {
                Obstacle obstacle = (Obstacle)actor;
                Body body = obstacle.GetBody();

                if (obstacle.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    _videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Image image = obstacle.GetImage();
                Point position = body.GetPosition();
                _videoService.DrawImage(image, position);
            }
        }
    }
}