// IMPLEMENT USING TILES NOT BRICKS


// using System.Collections.Generic;
// using Unit06.Game.Casting;
// using Unit06.Game.Services;


// namespace Unit06.Game.Scripting
// {
//     public class DrawTilesAction : Action
//     {
//         private VideoService _videoService;
        
//         public DrawTilesAction(VideoService videoService)
//         {
//             this._videoService = videoService;
//         }

//         public void Execute(Cast cast, Script script, ActionCallback callback)
//         {
//             List<Actor> bricks = cast.GetActors(Constants.TILE_GROUP);
//             foreach (Actor actor in bricks)
//             {
//                 Brick brick = (Brick)actor;
//                 Body body = brick.GetBody();

//                 if (brick.IsDebug())
//                 {
//                     Rectangle rectangle = body.GetRectangle();
//                     Point size = rectangle.GetSize();
//                     Point pos = rectangle.GetPosition();
//                     _videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
//                 }

//                 Animation animation = brick.GetAnimation();
//                 Image image = animation.NextImage();
//                 Point position = body.GetPosition();
//                 _videoService.DrawImage(image, position);
//             }
//         }
//     }
// }