namespace Unit06.Game.Casting
{
    /// <summary>
    /// Something that moves in the game and interacts with the frog.
    /// </summary>
    public class Obstacle : Actor
    {
        private string _obstacleType;
        private Body _body;
        private Image _image;
        private bool _direction;
        private int _logSpeedIndex;

        /// <summary>
        /// Constructs a new instance of Obstacle.
        /// </summary>
        /// <param name="direction">Right is true, left is false.</param>
        public Obstacle(string obstacleType, Body body, Image image, bool direction, int logSpeedIndex = 0, bool debug = false) : base(debug)
        {
            this._obstacleType = obstacleType;
            this._body = body;
            this._image = image;
            this._direction = direction;
            this._logSpeedIndex = logSpeedIndex;
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public string GetObstacleType()
        {
            return _obstacleType;
        }

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return _body;
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <returns>The image.</returns>
        public Image GetImage()
        {
            return _image;
        }

        /// <summary>
        /// Releases obstacle in its given direction.
        /// </summary>
        public void Release()
        {
            double vx = 0;
            if (this._obstacleType == "car")
            {
                vx = _direction ? Constants.CAR_VELOCITY : -Constants.CAR_VELOCITY;
            }
            else if (this._obstacleType == "policeCar")
            {
                vx = _direction ? Constants.POLICE_CAR_VELOCITY : -Constants.POLICE_CAR_VELOCITY;
            }
            else if (this._obstacleType == "tricycle")
            {
                vx = _direction ? Constants.TRICYCLE_VELOCITY : -Constants.TRICYCLE_VELOCITY;
            }
            else if (this._obstacleType == "log")
            {
                vx = _direction ? Constants.LOG_VELOCITIES[_logSpeedIndex] : -Constants.LOG_VELOCITIES[_logSpeedIndex];
            }
            Point newVelocity = new Point((int)vx, 0);
            _body.SetVelocity(newVelocity);
        }
    }
}