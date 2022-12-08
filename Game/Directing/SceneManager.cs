using System;
using System.Collections.Generic;
using System.IO;
using Unit06.Game.Casting;
using Unit06.Game.Scripting;
using Unit06.Game.Services;


namespace Unit06.Game.Directing
{
    public class SceneManager
    {
        public static AudioService AudioService = new RaylibAudioService();
        public static KeyboardService KeyboardService = new RaylibKeyboardService();
        public static MouseService MouseService = new RaylibMouseService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();
        public static VideoService VideoService = new RaylibVideoService(Constants.GAME_NAME,
            Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.BLACK);
        private static Random _random = new Random();

        public SceneManager()
        {
        }

        public void PrepareScene(string scene, Cast cast, Script script)
        {
            if (scene == Constants.NEW_GAME)
            {
                PrepareNewGame(cast, script);
            }
            else if (scene == Constants.NEXT_LEVEL)
            {
                PrepareNextLevel(cast, script);
            }
            else if (scene == Constants.TRY_AGAIN)
            {
                PrepareTryAgain(cast, script);
            }
            else if (scene == Constants.IN_PLAY)
            {
                PrepareInPlay(cast, script);
            }
            else if (scene == Constants.GAME_OVER)
            {
                PrepareGameOver(cast, script);
            }
        }

        private void PrepareNewGame(Cast cast, Script script)
        {
            AddTiles(cast);
            AddStats(cast);
            AddLevel(cast);
            AddScore(cast);
            AddLives(cast);
            AddObstacles(cast);
            AddFrog(cast);
            AddDialog(cast, Constants.ENTER_TO_START);

            script.ClearAllActions();
            AddInitActions(script);
            AddLoadActions(script);

            ChangeSceneAction a = new ChangeSceneAction(KeyboardService, Constants.NEXT_LEVEL);
            script.AddAction(Constants.INPUT, a);

            AddOutputActions(script);
            AddUnloadActions(script);
            AddReleaseActions(script);
        }

        private void ActivateObstacles(Cast cast)
        {
            List<Actor> obstacles = cast.GetActors(Constants.OBSTACLE_GROUP);
            foreach (Actor actor in obstacles)
            {
                Obstacle obstacle = (Obstacle)actor;
                obstacle.Release();
            }
        }

        private void PrepareNextLevel(Cast cast, Script script)
        {
            // AddBall(cast);
            // AddBricks(cast);
            // AddRacket(cast);
            AddDialog(cast, Constants.PREP_TO_LAUNCH);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);

            PlaySoundAction sa = new PlaySoundAction(AudioService, Constants.WELCOME_SOUND);
            script.AddAction(Constants.OUTPUT, sa);
        }

        private void PrepareTryAgain(Cast cast, Script script)
        {
            // AddBall(cast);
            // AddRacket(cast);
            AddDialog(cast, Constants.PREP_TO_LAUNCH);

            script.ClearAllActions();
            
            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);
            
            AddUpdateActions(script);
            AddOutputActions(script);
        }

        private void PrepareInPlay(Cast cast, Script script)
        {
            ActivateObstacles(cast);
            cast.ClearActors(Constants.DIALOG_GROUP);

            script.ClearAllActions();

            // ControlRacketAction action = new ControlRacketAction(KeyboardService);
            // script.AddAction(Constants.INPUT, action);

            AddUpdateActions(script);    
            AddOutputActions(script);
        
        }

        private void PrepareGameOver(Cast cast, Script script)
        {
            // AddBall(cast);
            // AddRacket(cast);
            AddDialog(cast, Constants.WAS_GOOD_GAME);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.NEW_GAME, 5, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);
        }

        // -----------------------------------------------------------------------------------------
        // casting methods
        // -----------------------------------------------------------------------------------------

        private void AddObstacles(Cast cast)
        {
            cast.ClearActors(Constants.OBSTACLE_GROUP);
        
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            // int level = stats.GetLevel() % Constants.BASE_LEVELS;
            int level = 1;
            string filename = string.Format(Constants.LEVEL_OBSTACLES_FILE, level);
            List<List<string>> rows = LoadLevel(filename);

            for (int r = 0; r < rows.Count; r++)
            {
                for (int c = 0; c < rows[r].Count; c++)
                {
                    string type = rows[r][c][0].ToString();
                    int x = Constants.FIELD_LEFT + c * Constants.TILE_SIZE;
                    int y = Constants.FIELD_TOP + r * Constants.TILE_SIZE;
                    if (type == "t")
                    {
                        string obstacleType = "tricycle";

                        int direction = (int)Char.GetNumericValue(rows[r][c][1]);
                        bool boolDirection = (direction == 0) ? true : false;
                        Point position = new Point(x, y);
                        Point size = new Point((int)(Constants.TRICYCLE_WIDTH * Constants.TRICYCLE_SCALE), (int)(Constants.TRICYCLE_HEIGHT * Constants.TRICYCLE_SCALE));
                        Point velocity = new Point((direction == 0) ? Constants.TRICYCLE_VELOCITY : -Constants.TRICYCLE_VELOCITY, 0);
                        Body body = new Body(position, size, velocity);

                        int randomIndex = _random.Next(Constants.TRICYCLE_IMAGES.Count);
                        string fileName = Constants.TRICYCLE_IMAGES[randomIndex];
                        int rotation = (direction == 0) ? 90 : 0; 
                        Image image = new Image(fileName, Constants.TRICYCLE_SCALE, rotation);

                        Obstacle obstacle = new Obstacle(obstacleType, body, image, boolDirection);
                        cast.AddActor(Constants.OBSTACLE_GROUP, obstacle);
                    }
                    else if (type == "c")
                    {
                        string obstacleType = "car";

                        int direction = (int)Char.GetNumericValue(rows[r][c][1]);
                        bool boolDirection = (direction == 0) ? true : false;
                        Point position = new Point(x, y);
                        Point size = new Point((int)(Constants.CAR_WIDTH * Constants.CAR_SCALE), (int)(Constants.CAR_HEIGHT * Constants.CAR_SCALE));
                        Point velocity = new Point((direction == 0) ? Constants.CAR_VELOCITY : -Constants.CAR_VELOCITY, 0);
                        Body body = new Body(position, size, velocity);

                        int randomIndex = _random.Next(Constants.CAR_IMAGES.Count);
                        string fileName = Constants.CAR_IMAGES[randomIndex];
                        int rotation = (direction == 0) ? 90 : 0; 
                        Image image = new Image(fileName, Constants.CAR_SCALE, rotation);

                        Obstacle obstacle = new Obstacle(obstacleType, body, image, boolDirection);
                        cast.AddActor(Constants.OBSTACLE_GROUP, obstacle);
                    }
                    else if (type == "l")
                    {
                        string obstacleType = "log";

                        int direction = 1;
                        int logSpeedIndex = (int)Char.GetNumericValue(rows[r][c][1]);
                        bool boolDirection = (direction == 0) ? true : false;
                        Point position = new Point(x, y);
                        Point size = new Point((int)(Constants.LOG_WIDTH * Constants.LOG_SCALE), (int)(Constants.PLAIN_LOG_HEIGHT * Constants.LOG_SCALE));
                        Point velocity = new Point(-Constants.LOG_VELOCITIES[logSpeedIndex], 0);
                        Body body = new Body(position, size, velocity);

                        int randomIndex = _random.Next(Constants.LOG_IMAGES.Count);
                        string fileName = Constants.LOG_IMAGES[randomIndex];
                        Image image = new Image(fileName, Constants.CAR_SCALE);

                        Obstacle obstacle = new Obstacle(obstacleType, body, image, boolDirection, logSpeedIndex);
                        cast.AddActor(Constants.OBSTACLE_GROUP, obstacle);
                    }
                    else if (type == "n")
                    {
                    }
                    else
                    {
                        throw new Exception("obstacle type not recognized");
                    }
                }
            }
        }

        private void AddTiles(Cast cast)
        {
            cast.ClearActors(Constants.TILE_GROUP);

            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            // int level = stats.GetLevel() % Constants.BASE_LEVELS;
            int level = 1;
            string filename = string.Format(Constants.LEVEL_TILES_FILE, level);
            List<List<string>> rows = LoadLevel(filename);

            for (int r = 0; r < rows.Count; r++)
            {
                for (int c = 0; c < rows[r].Count; c++)
                {
                    int x = Constants.FIELD_LEFT + c * Constants.TILE_SIZE;
                    int y = Constants.FIELD_TOP + r * Constants.TILE_SIZE;

                    string type = rows[r][c][0..2].ToString();
                    int info = (int)Char.GetNumericValue(rows[r][c][1]);

                    Point position = new Point(x, y);
                    Point size = new Point((int)(Constants.TILE_SIZE * Constants.TILE_SCALE), (int)(Constants.TILE_SIZE * Constants.TILE_SCALE));
                    Point velocity = new Point(0, 0);

                    int detail = (int)Char.GetNumericValue(rows[r][c][2]);
                    // Console.WriteLine($"row: {r}, column: {c}, detail: {detail}");
                    int tileIndex = 0;
                    if (detail == 0)
                    {
                        if (type == "gg" || type == "gr" || type == "rg")
                        {
                            tileIndex = _random.Next(4);
                        }
                        else if (type == "ww")
                        {
                            tileIndex = 0;
                        }
                    }
                    else if (detail == 1)
                    {
                        if (type == "gg" || type == "gr" || type == "rg")
                        {
                            tileIndex = _random.Next(4, 8);
                        }
                        else if (type == "ww")
                        {
                            tileIndex = _random.Next(1, 5);
                        }
                        else if (type == "rr")
                        {
                            tileIndex = 0;
                        }
                    }
                    else if (detail > 1)
                    {
                        tileIndex = detail - 1;
                    }
                    Image image = new Image(Constants.TILE_IMAGES[type][tileIndex], Constants.TILE_SCALE);

                    Body body = new Body(position, size, velocity);
                    
                    Tile tile = new Tile(body, image, false);
                    cast.AddActor(Constants.TILE_GROUP, tile);
                }
            }
        }

        private void AddDialog(Cast cast, string message)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);

            Text text = new Text(message, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.WHITE);
            Point position = new Point(Constants.CENTER_X, Constants.CENTER_Y);

            Label label = new Label(text, position);
            cast.AddActor(Constants.DIALOG_GROUP, label);   
        }

        private void AddLevel(Cast cast)
        {
            cast.ClearActors(Constants.LEVEL_GROUP);

            Text text = new Text(Constants.LEVEL_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_LEFT, Constants.WHITE);
            Point position = new Point(Constants.HUD_MARGIN, Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.LEVEL_GROUP, label);
        }

        private void AddLives(Cast cast)
        {
            cast.ClearActors(Constants.LIVES_GROUP);

            Text text = new Text(Constants.LIVES_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_RIGHT, Constants.WHITE);
            Point position = new Point(Constants.SCREEN_WIDTH - Constants.HUD_MARGIN, 
                Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.LIVES_GROUP, label);   
        }


        // CHANGE TO ADD FROG

        private void AddFrog(Cast cast)
        {
            cast.ClearActors(Constants.FROG_GROUP);
        
            int x = Constants.CENTER_X - Constants.FROG_WIDTH / 2;
            int y = Constants.SCREEN_HEIGHT - Constants.FROG_SIT_HEIGHT;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.FROG_WIDTH, Constants.FROG_SIT_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            List<Image> images = new List<Image>();
            foreach (string imageFile in Constants.FROG_IMAGES)
            {
                images.Add(new Image(imageFile, Constants.FROG_SCALE));
            }
            Frog frog = new Frog(body, images, false);
        
            cast.AddActor(Constants.FROG_GROUP, frog);
        }

        private void AddScore(Cast cast)
        {
            cast.ClearActors(Constants.SCORE_GROUP);

            Text text = new Text(Constants.SCORE_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.WHITE);
            Point position = new Point(Constants.CENTER_X, Constants.HUD_MARGIN);
            
            Label label = new Label(text, position);
            cast.AddActor(Constants.SCORE_GROUP, label);   
        }

        private void AddStats(Cast cast)
        {
            cast.ClearActors(Constants.STATS_GROUP);
            Stats stats = new Stats();
            cast.AddActor(Constants.STATS_GROUP, stats);
        }

        private List<List<string>> LoadLevel(string filename)
        {
            List<List<string>> data = new List<List<string>>();
            using(StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    List<string> columns = new List<string>(row.Split(',', StringSplitOptions.TrimEntries));
                    data.Add(columns);
                }
            }
            return data;
        }

        // -----------------------------------------------------------------------------------------
        // scripting methods
        // -----------------------------------------------------------------------------------------

        private void AddInitActions(Script script)
        {
            script.AddAction(Constants.INITIALIZE, new InitializeDevicesAction(AudioService, 
                VideoService));
        }

        private void AddLoadActions(Script script)
        {
            script.AddAction(Constants.LOAD, new LoadAssetsAction(AudioService, VideoService));
        }

        private void AddOutputActions(Script script)
        {
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawTilesAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawObstaclesAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawRacketAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawDialogAction(VideoService));
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));
        }

        private void AddUnloadActions(Script script)
        {
            script.AddAction(Constants.UNLOAD, new UnloadAssetsAction(AudioService, VideoService));
        }

        private void AddReleaseActions(Script script)
        {
            script.AddAction(Constants.RELEASE, new ReleaseDevicesAction(AudioService, 
                VideoService));
        }

        private void AddUpdateActions(Script script)
        {
            script.AddAction(Constants.UPDATE, new MoveObstaclesAction());
            // script.AddAction(Constants.UPDATE, new MoveRacketAction());
            // script.AddAction(Constants.UPDATE, new CollideBordersAction(PhysicsService, AudioService));
            // script.AddAction(Constants.UPDATE, new CollideBrickAction(PhysicsService, AudioService));
            // script.AddAction(Constants.UPDATE, new CollideRacketAction(PhysicsService, AudioService));
            // script.AddAction(Constants.UPDATE, new CheckOverAction());     
        }
    }
}