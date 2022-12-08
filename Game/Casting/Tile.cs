namespace Unit06.Game.Casting
{
    /// <summary>
    /// A background element.
    /// </summary>
    public class Tile : Actor
    {
        private Body _body;
        private Image _image;

        /// <summary>
        /// Constructs a new instance of Tile.
        /// </summary>
        public Tile(Body body, Image image, bool debug) : base(debug)
        {
            this._body = body;
            this._image = image;
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
        
    }
}