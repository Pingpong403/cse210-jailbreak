using System.Collections.Generic;

namespace Unit06.Game.Casting
{
    /// <summary>
    /// The frog in question.
    /// </summary>
    public class Frog : Actor
    {
        private Body _body;
        private List<Image> _images= new List<Image>();
        private Image _image;
        private bool _jumping;
        private Point _lastJumpPosition;
        private int _direction;
        private bool _canJumpUp = true;
        private bool _canJumpRight = true;
        private bool _canJumpDown = true;
        private bool _canJumpLeft = true;
        
        /// <summary>
        /// Constructs a new instance of Frog.
        /// </summary>
        public Frog(Body body, List<Image> images, bool debug) : base(debug)
        {
            this._body = body;
            this._images = images;
            _image = this._images[Constants.FROG_SIT_INDEX];
            _jumping = false;
            _lastJumpPosition = this._body.GetPosition();
            _direction = 0;
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
        /// Gets the image
        /// </summary>
        /// <returns>The image.</returns>
        public Image GetImage()
        {
            return _image;
        }

        /// <summary>
        /// Gets the frog's jumping status.
        /// </summary>
        /// <returns>True if the frog is jumping. False if he is sitting.</returns>
        public bool IsJumping()
        {
            return _jumping;
        }

        /// <summary>
        /// Gets the frog's last jump position.
        /// </summary>
        /// <returns>The position.</returns>
        public Point GetLastJumpPosition()
        {
            return _lastJumpPosition;
        }

        /// <summary>
        /// Gets the frog's direction.
        /// </summary>
        /// <returns>The direction.</returns>
        public int GetDirection()
        {
            return _direction;
        }

        /// <summary>
        /// Jumps the frog up.
        /// </summary>
        public void JumpUp()
        {
            Point velocity = new Point(0, -Constants.FROG_JUMP_INIT_VELOCITY);
            _body.SetVelocity(velocity);
            _image = _images[Constants.FROG_JUMP_INDEX];
            _jumping = true;
            _direction = 0;
            _lastJumpPosition = _body.GetPosition();
        }

        /// <summary>
        /// Jumps the frog to the right.
        /// </summary>
        public void JumpRight()
        {
            Point velocity = new Point(Constants.FROG_JUMP_INIT_VELOCITY, 0);
            _body.SetVelocity(velocity);
            _image = _images[Constants.FROG_JUMP_INDEX + 2];
            _jumping = true;
            _direction = 1;
            _lastJumpPosition = _body.GetPosition();
        }

        /// <summary>
        /// Jumps the frog down.
        /// </summary>
        public void JumpDown()
        {
            Point velocity = new Point(0, Constants.FROG_JUMP_INIT_VELOCITY);
            _body.SetVelocity(velocity);
            _image = _images[Constants.FROG_JUMP_INDEX + 4];
            _jumping = true;
            _direction = 2;
            _lastJumpPosition = _body.GetPosition();
        }

        /// <summary>
        /// Jumps the frog to the left.
        /// </summary>
        public void JumpLeft()
        {
            Point velocity = new Point(-Constants.FROG_JUMP_INIT_VELOCITY, 0);
            _body.SetVelocity(velocity);
            _image = _images[Constants.FROG_JUMP_INDEX + 6];
            _jumping = true;
            _direction = 3;
            _lastJumpPosition = _body.GetPosition();
        }

        /// <summary>
        /// Stops the frog from moving.
        /// </summary>
        public void StopMoving()
        {
            Point velocity = new Point(0, 0);
            _body.SetVelocity(velocity);
            _image = _images[Constants.FROG_SIT_INDEX + 2 * _direction];
            _jumping = false;
            _lastJumpPosition = _body.GetPosition();
        }

        /// <summary>
        /// Control which direction the frog can jump.
        /// </summary>
        public void ControlJump(string direction, bool control)
        {
            if (direction == "up")
            {
                _canJumpUp = control;
            }
            else if (direction == "right")
            {
                _canJumpRight = control;
            }
            else if (direction == "down")
            {
                _canJumpDown = control;
            }
            else if (direction == "left")
            {
                _canJumpLeft = control;
            }
            else
            {
                throw new System.Exception($"direction '{direction}' not recognized");
            }
        }

        /// <summary>
        /// Check if the frog can move in the given direction.
        /// </summary>
        /// <returns>True if the frog can move in the direction, false if otherwise.
        /// </returns>
        /// <param name="direction">The direction to check.</param>
        public bool CanJump(string direction)
        {
            if (direction == "up")
            {
                return _canJumpUp;
            }
            else if (direction == "right")
            {
                return _canJumpRight;
            }
            else if (direction == "down")
            {
                return _canJumpDown;
            }
            else if (direction == "left")
            {
                return _canJumpLeft;
            }
            else
            {
                throw new System.Exception($"direction '{direction}' not recognized");
            }
        }
    }
}