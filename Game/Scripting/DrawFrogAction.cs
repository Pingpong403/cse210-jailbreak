using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawRacketAction : Action
    {
        private VideoService _videoService;
        
        public DrawRacketAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Frog racket = (Frog)cast.GetFirstActor(Constants.FROG_GROUP);
            Body body = racket.GetBody();

            if (racket.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                _videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }

            Point position = body.GetPosition();
            // IMPLEMENT JUMP ANIMATION (NOT AN ANIMATION OBJECT) USING FILENAMES
            Image image = racket.GetImage();
            _videoService.DrawImage(image, position);
        }
    }
}