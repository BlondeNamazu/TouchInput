using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject
{
    class UI
    {
        // どのUIにも対応していない場所でタッチされたときのID
        public int moveId;

        public UI()
        {
            // ボタン等のUIパーツの定義等を行う
        }

        virtual public void Update()
        {
            // 各UIパーツごとの処理
        }

        virtual public void Draw(SpriteBatch spriteBatch)
        {
            // UIの描画
        }


        virtual public Vector2 GetMouseVelocity(int id, int frames)
        {
            // 例外処理
            if (!Input.touches.ContainsKey(id)) return Vector2.Zero;
            if (frames > Input.DELAY_FRAME) return Vector2.Zero;
            return Input.touches[id].Positions[0] - Input.touches[id].Positions[frames - 1];
        }
    }
}
