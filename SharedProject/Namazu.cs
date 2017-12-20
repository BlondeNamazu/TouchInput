using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject
{
    public class Namazu
    {
        private Vector2 position;
        private float velocity;
        public Namazu(Vector2 center)
        {
            this.position = center;
            this.velocity = 3.0f;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Graphics.Namazu, new Rectangle((int)(position.X - Graphics.Namazu.Width / 2), (int)(position.Y - Graphics.Namazu.Height / 2), Graphics.Namazu.Width, Graphics.Namazu.Height), Color.White);
        }
        public void moveTo(Vector2 vec)
        {
            this.position = vec;
        }
        public void move(Vector2 vec)
        {
            this.position += vec * velocity;
        }
    }
}
