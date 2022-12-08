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
        
        /// <summary>
        /// Constructs a new instance of Frog.
        /// </summary>
        public Frog(Body body, List<Image> images, bool debug) : base(debug)
        {
            this._body = body;
            this._images = images;
            this._image = this._images[Constants.FROG_SIT_INDEX];
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
        /// Moves the frog to its next position.
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
            this._image = this._images[Constants.FROG_JUMP_INDEX];
        }

        /// <summary>
        /// Jumps the frog to the right.
        /// </summary>
        public void JumpRight()
        {
            Point velocity = new Point(Constants.FROG_JUMP_INIT_VELOCITY, 0);
            _body.SetVelocity(velocity);
            this._image = this._images[Constants.FROG_JUMP_INDEX];
        }

        /// <summary>
        /// Jumps the frog up.
        /// </summary>
        public void JumpUp()
        {
            Point velocity = new Point(0, -Constants.FROG_JUMP_INIT_VELOCITY);
            _body.SetVelocity(velocity);
            this._image = this._images[Constants.FROG_JUMP_INDEX];
        }

        /// <summary>
        /// Jumps the frog down.
        /// </summary>
        public void JumpDown()
        {
            Point velocity = new Point(0, Constants.FROG_JUMP_INIT_VELOCITY);
            _body.SetVelocity(velocity);
            this._image = this._images[Constants.FROG_JUMP_INDEX];
        }

        /// <summary>
        /// Stops the frog from moving.
        /// </summary>
        public void StopMoving()
        {
            Point velocity = new Point(0, 0);
            _body.SetVelocity(velocity);
            this._image = this._images[Constants.FROG_SIT_INDEX];
        }
    }
}