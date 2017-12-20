using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject
{
    static class Graphics
    {
        public static Texture2D ButtonUp { get; private set; }
        public static Texture2D ButtonRight { get; private set; }
        public static Texture2D ButtonLeft { get; private set; }
        public static Texture2D ButtonDown { get; private set; }
        public static Texture2D ButtonChange { get; private set; }
        public static Texture2D Namazu { get; private set; }

        /// <summary>
        /// 画像読み込み
        /// </summary>
        /// <param name="content">ContentManager</param>
        public static void Load(ContentManager content)
        {
            ButtonUp = content.Load<Texture2D>("ButtonUp");
            ButtonRight = content.Load<Texture2D>("ButtonRight");
            ButtonDown = content.Load<Texture2D>("ButtonDown");
            ButtonLeft = content.Load<Texture2D>("ButtonLeft");
            ButtonChange = content.Load<Texture2D>("ButtonChange");
            Namazu = content.Load<Texture2D>("Namazu");
        }
    }
}
