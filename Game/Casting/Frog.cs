namespace Unit06.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Frog : Actor
    {
        private Body _body;
        
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Frog(Body body, bool debug) : base(debug)
        {
            this._body = body;
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
        /// Moves the racket to its next position.
        /// </summary>
        public void MoveNext()
        {
            Point position = _body.GetPosition();
            Point velocity = _body.GetVelocity();
            Point newPosition = position.Add(velocity);
            _body.SetPosition(newPosition);
            _body.SetVelocity(_body.GetVelocity().Accelerate(Constants.FROG_JUMP_ACCELERATION));
        }

        /// <summary>
        /// Jumps the frog to the left.
        /// </summary>
        public void JumpLeft()
        {
            Point velocity = new Point(-Constants.FROG_JUMP_INIT_VELOCITY, 0);
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Jumps the frog to the right.
        /// </summary>
        public void JumpRight()
        {
            Point velocity = new Point(Constants.FROG_JUMP_INIT_VELOCITY, 0);
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Jumps the frog up.
        /// </summary>
        public void JumpUp()
        {
            Point velocity = new Point(0, -Constants.FROG_JUMP_INIT_VELOCITY);
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Jumps the frog down.
        /// </summary>
        public void JumpDown()
        {
            Point velocity = new Point(0, Constants.FROG_JUMP_INIT_VELOCITY);
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Stops the racket from moving.
        /// </summary>
        public void StopMoving()
        {
            Point velocity = new Point(0, 0);
            _body.SetVelocity(velocity);
        }
        
    }
}