using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject
{
    // 抽象メソッド
    delegate void PressBeginHandler();
    delegate void OnPressHandler();
    delegate void PressEndHandler();
    class Button
    {
        public PressBeginHandler _begin;
        public OnPressHandler _onPress;
        public PressEndHandler _end;

        private Vector2 position;
        private float radius;
        private Texture2D texture;
        public bool isPressed;
        public int touchId;

    #if DEBUG
        static private int count = 0;
        private int ButtonId;
    #endif
        public Rectangle rect { get; set; }

        /// <summary>
        /// 押しているボタンのID
        /// </summary>
        public int id;
        public Color color { get; set; }

        /// <summary>
        /// ボタン位置、サイズ、形の初期化
        /// </summary>
        /// <param name="shape">ボタンの形</param>
        /// <param name="rect">位置とサイズ(楕円は不可)</param>
        public Button(Texture2D texture, Vector2 position, float radius, Color color)
        {
            this.position = position;
            this.radius = radius;
            this.rect = new Rectangle((int)(position.X - radius), (int)(position.Y - radius), (int)(radius * 2), (int)(radius * 2));
            this.color = new Color(255, 255, 255);
            this.texture = texture;
            this.isPressed = false;
            this.touchId = -1;
    #if DEBUG
            ButtonId = count;
            count++;
    #endif
            _begin = () => { Console.WriteLine("Default PressBegin Handler is called"); };
            _onPress = () => { Console.WriteLine("Default OnPressed Handler is called"); };
            _end = () => { Console.WriteLine("Default PressEnd Handler is called"); };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, isPressed ? Color.Gray : color);
        }

        public bool Pressed(Vector2 vec)
        {
            return (this.position - vec).Length() <= this.radius;
        }
    }
}
