using System.Collections.Generic;
using Unit06.Game.Casting;


namespace Unit06
{
    public class Constants
    {
        // ----------------------------------------------------------------------------------------- 
        // GENERAL GAME CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // GAME
        public static string GAME_NAME = "Prison Break Frogger";
        public static int FRAME_RATE = 60;

        // SCREEN
        public static int TILE_NUMBERS_WIDTH = 10;
        public static int TILE_NUMBERS_HEIGHT = 16;
        public static int SCREEN_WIDTH = (int)(TILE_SIZE * TILE_SCALE * TILE_NUMBERS_WIDTH);
        public static int SCREEN_HEIGHT = (int)(TILE_SIZE * TILE_SCALE * TILE_NUMBERS_HEIGHT);
        public static int CENTER_X = SCREEN_WIDTH / 2;
        public static int CENTER_Y = SCREEN_HEIGHT / 2;

        // FIELD
        public static int FIELD_TOP = 0;
        public static int FIELD_BOTTOM = SCREEN_HEIGHT;
        public static int FIELD_LEFT = 0;
        public static int FIELD_RIGHT = SCREEN_WIDTH;

        // FONT
        public static string FONT_FILE = "Assets/Fonts/zorque.otf";
        public static int FONT_SIZE = 32;

        // SOUND
        public static string BOUNCE_SOUND = "Assets/Sounds/boing.wav";
        public static string WELCOME_SOUND = "Assets/Sounds/start.wav";
        public static string OVER_SOUND = "Assets/Sounds/over.wav";

        // TEXT
        public static int ALIGN_LEFT = 0;
        public static int ALIGN_CENTER = 1;
        public static int ALIGN_RIGHT = 2;


        // COLORS
        public static Color BLACK = new Color(0, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color PURPLE = new Color(255, 0, 255);

        // KEYS
        public static string LEFT = "left";
        public static string RIGHT = "right";
        public static string UP = "up";
        public static string DOWN = "down";
        public static string SPACE = "space";
        public static string ENTER = "enter";
        public static string PAUSE = "p";

        // SCENES
        public static string NEW_GAME = "new_game";
        public static string TRY_AGAIN = "try_again";
        public static string NEXT_LEVEL = "next_level";
        public static string IN_PLAY = "in_play";
        public static string GAME_OVER = "game_over";

        // LEVELS
        public static string LEVEL_TILES_FILE = "Assets/Data/TileMaps/level-{0:000}.txt";
        public static string LEVEL_OBSTACLES_FILE = "Assets/Data/ObstacleMaps/level-{0:000}.txt";
        public static int BASE_LEVELS = 1;

        // ----------------------------------------------------------------------------------------- 
        // SCRIPTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // PHASES
        public static string INITIALIZE = "initialize";
        public static string LOAD = "load";
        public static string INPUT = "input";
        public static string UPDATE = "update";
        public static string OUTPUT = "output";
        public static string UNLOAD = "unload";
        public static string RELEASE = "release";

        // ----------------------------------------------------------------------------------------- 
        // CASTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // STATS
        public static string STATS_GROUP = "stats";
        public static int DEFAULT_LIVES = 3;
        public static int MAXIMUM_LIVES = 5;

        // HUD
        public static int HUD_MARGIN = 15;
        public static string LEVEL_GROUP = "level";
        public static string LIVES_GROUP = "lives";
        public static string SCORE_GROUP = "score";
        public static string LEVEL_FORMAT = "LEVEL: {0}";
        public static string LIVES_FORMAT = "LIVES: {0}";
        public static string SCORE_FORMAT = "SCORE: {0}";

        // FROG
        public static string FROG_GROUP = "frogs";
        
        public static List<string> FROG_IMAGES
            = new List<string>() {
                "Assets/Images/5001.png",
                "Assets/Images/5002.png"
            };
        public static int FROG_SIT_INDEX = 0;
        public static int FROG_JUMP_INDEX = 1;

        public static int FROG_WIDTH = 288;
        public static int FROG_SIT_HEIGHT = 288;
        public static int FROG_JUMP_HEIGHT = 384;
        public static int FROG_JUMP_VERTICAL_CENTER = 176;
        public static double FROG_SCALE = 0.1;
        public static int FROG_JUMP_ACCELERATION = -1;
        public static int FROG_JUMP_INIT_VELOCITY = 5;

        // OBSTACLES
        public static string OBSTACLE_GROUP = "obstacles";

        // CARS
        
        public static List<string> CAR_IMAGES
            = new List<string>() {
                "Assets/Images/6001.png",
                "Assets/Images/6002.png",
                "Assets/Images/6003.png",
                "Assets/Images/6004.png",
                "Assets/Images/6005.png"
            };

        public static int POLICE_CAR_INDEX = 4;
        public static int CAR_WIDTH = 576;
        public static int CAR_HEIGHT = 288;
        public static double CAR_SCALE = 0.1;
        public static int CAR_VELOCITY = 5;
        public static int POLICE_CAR_VELOCITY = 7;

        // TRICYCLES

        public static List<string> TRICYCLE_IMAGES
            = new List<string>() {
                "Assets/Images/7001.png",
                "Assets/Images/7002.png",
                "Assets/Images/7003.png",
                "Assets/Images/7004.png",
                "Assets/Images/7005.png"
            };
        
        public static int TRICYCLE_WIDTH = 288;
        public static int TRICYCLE_HEIGHT = 288;
        public static double TRICYCLE_SCALE = 0.1;
        public static int TRICYCLE_VELOCITY = 3;

        // LOGS

        public static List<string> LOG_IMAGES
            = new List<string>() {
                "Assets/Images/8001.png",
                "Assets/Images/8101.png",
                "Assets/Images/8102.png",
                "Assets/Images/8103.png",
                "Assets/Images/8104.png",
                "Assets/Images/8105.png"
            };

        public static int LOG_WIDTH = 352;
        public static int PLAIN_LOG_HEIGHT = 160;
        public static int DETAIL_LOG_HEIGHT = 288;
        public static double LOG_SCALE = 0.1;
        public static List<int> LOG_VELOCITIES
            = new List<int>() {
                2,
                4,
                6
            };

        // TILES
        public static string TILE_GROUP = "tiles";
        
        public static Dictionary<string, List<string>> TILE_IMAGES
            = new Dictionary<string, List<string>>() {
                { "gg", new List<string>() {
                    "Assets/Images/0001.png",
                    "Assets/Images/0002.png",
                    "Assets/Images/0003.png",
                    "Assets/Images/0004.png",
                    "Assets/Images/0101.png",
                    "Assets/Images/0102.png",
                    "Assets/Images/0103.png",
                    "Assets/Images/0104.png",
                } },
                { "gr", new List<string>() {
                    "Assets/Images/1001.png",
                    "Assets/Images/1002.png",
                    "Assets/Images/1003.png",
                    "Assets/Images/1004.png",
                    "Assets/Images/1101.png",
                    "Assets/Images/1102.png",
                    "Assets/Images/1103.png",
                    "Assets/Images/1104.png"
                } },
                { "rg", new List<string>() {
                    "Assets/Images/1005.png",
                    "Assets/Images/1006.png",
                    "Assets/Images/1007.png",
                    "Assets/Images/1008.png",
                    "Assets/Images/1105.png",
                    "Assets/Images/1106.png",
                    "Assets/Images/1107.png",
                    "Assets/Images/1108.png"
                } },
                { "rr", new List<string>() {
                    "Assets/Images/2001.png",
                    "Assets/Images/2002.png",
                    "Assets/Images/2003.png"
                } },
                { "gw", new List<string>() {
                    "Assets/Images/3001.png",
                    "Assets/Images/3002.png",
                    "Assets/Images/3003.png",
                    "Assets/Images/3004.png"
                } },
                { "wg", new List<string>() {
                    "Assets/Images/3005.png",
                    "Assets/Images/3006.png",
                    "Assets/Images/3007.png",
                    "Assets/Images/3008.png"
                } },
                { "ww", new List<string>() {
                    "Assets/Images/4001.png",
                    "Assets/Images/4101.png",
                    "Assets/Images/4102.png",
                    "Assets/Images/4103.png",
                    "Assets/Images/4104.png",
                    "Assets/Images/4105.png"
                } }
        };

        public static int TILE_SIZE = 320;
        public static double TILE_SCALE = 0.1;

        // DIALOG
        public static string DIALOG_GROUP = "dialogs";
        public static string ENTER_TO_START = "PRESS ENTER TO START";
        public static string PREP_TO_LAUNCH = "PREPARING TO LAUNCH";
        public static string WAS_GOOD_GAME = "GAME OVER";

    }
}