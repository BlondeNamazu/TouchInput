using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedProject
{
    static class UIManager
    {
        public enum UIType
        {
            None,
            Button,
            Touch
        }
        public static UIType NextUI;
        public static UI CurrentUI;
        public static List<int> oldIds;

        public static void Init()
        {
            NextUI = UIType.Button;
            oldIds = new List<int>();
        }

        public static void Update()
        {
            UI newUI;
            switch (NextUI)
            {
                case UIType.Button:
                    newUI = new ButtonUI();
                    CurrentUI = newUI;
                    NextUI = UIType.None;
                    oldIds = Input.touches.Keys.ToList();
                    break;
                case UIType.Touch:
                    newUI = new TouchUI();
                    CurrentUI = newUI;
                    NextUI = UIType.None;
                    oldIds = Input.touches.Keys.ToList();
                    break;
                case UIType.None:
                    break;
            }
            CurrentUI.Update();
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            CurrentUI.Draw(spriteBatch);
        }
    }
}
