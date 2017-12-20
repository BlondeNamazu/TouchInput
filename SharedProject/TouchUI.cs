using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject
{
    class TouchUI : UI
    {
        public Button ButtonChange;
        int buttonRadius = 45;

        public TouchUI()
        {
            // ボタン本体の定義
            ButtonChange = new Button(Graphics.ButtonChange, new Vector2(buttonRadius * 2, Game1.ScreenSize.Y - buttonRadius * 2), buttonRadius, Color.White);

            // ボタンのイベントハンドラの登録
            ButtonChange._begin = ButtonChange_begin;
            ButtonChange._onPress = ButtonChange_onPress;
            ButtonChange._end = ButtonChange_end;

        }

        public override void Update()
        {
            #region タッチの検出

            #region 既存のタッチを更新する
            //切り替えボタン用のタッチが継続している時
            if (Input.touches.ContainsKey(ButtonChange.touchId))
            {

            }
            else { ButtonChange.touchId = -1; }
            //移動用のタッチが継続している時
            if (Input.touches.ContainsKey(moveId))
            {

            }
            else { moveId = -1; }
            #endregion

            #region 新しいタッチを検出する
            foreach (var newInfo in Input.touches.Values)
            {
                if (newInfo.Id == ButtonChange.touchId ||
                    newInfo.Id == moveId) continue;
                if (UIManager.oldIds.Contains(newInfo.Id)) continue;
                //新しい切り替えボタン用タッチを見つけた時
                if (ButtonChange.touchId == -1 && ButtonChange.Pressed(newInfo.Positions[0]))
                {
                    ButtonChange.touchId = newInfo.Id;
                }
                //新しい移動用タッチを見つけた時
                else if (moveId == -1)
                {
                    moveId = newInfo.Id;
                }
            }
            #endregion

            #endregion

            #region タッチの処理（移動以外の処理の中身は「ボタンのイベントハンドラ」に記述）
            #region 切り替えボタン用タッチの処理
            if (Input.touches.ContainsKey(ButtonChange.touchId))
            {
                switch (Input.touches[ButtonChange.touchId].State)
                {
                    case Input.TouchState.Begin:
                        ButtonChange._begin();
                        break;
                    case Input.TouchState.OnTouch:
                        ButtonChange._onPress();
                        break;
                    case Input.TouchState.End:
                        ButtonChange._end();
                        break;
                }
            }
            #endregion
            #region 移動用タッチの処理
            if (Input.touches.ContainsKey(moveId))
            {
                switch (Input.touches[moveId].State)
                {
                    case Input.TouchState.Begin:
                    case Input.TouchState.OnTouch:
                        Game1.namazu.moveTo(Input.touches[moveId].Positions[0]);
                        break;
                    case Input.TouchState.End:
                        break;
                }
            }
            #endregion
            #endregion


        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            ButtonChange.Draw(spriteBatch);
        }

        #region ボタンのイベントハンドラ
        public void ButtonChange_begin()
        {
            ButtonChange.isPressed = true;
        }
        public void ButtonChange_onPress()
        {

        }
        public void ButtonChange_end()
        {
            ButtonChange.isPressed = false;
            UIManager.NextUI = UIManager.UIType.Button;
        }
        #endregion



    }
}
