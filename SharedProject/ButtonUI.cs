using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject
{
    class ButtonUI : UI
    {
        public Button ButtonUp, ButtonRight, ButtonDown, ButtonLeft, ButtonChange;
        int buttonRadius = 45;

        public ButtonUI()
        {
            // ボタン本体の定義
            ButtonUp        = new Button(Graphics.ButtonUp,     new Vector2(Game1.ScreenSize.X - buttonRadius * 5, Game1.ScreenSize.Y - buttonRadius * 5), buttonRadius, Color.White);
            ButtonRight     = new Button(Graphics.ButtonRight,  new Vector2(Game1.ScreenSize.X - buttonRadius * 2, Game1.ScreenSize.Y - buttonRadius * 2), buttonRadius, Color.White);
            ButtonDown      = new Button(Graphics.ButtonDown,   new Vector2(Game1.ScreenSize.X - buttonRadius * 5, Game1.ScreenSize.Y - buttonRadius * 2), buttonRadius, Color.White);
            ButtonLeft      = new Button(Graphics.ButtonLeft,   new Vector2(Game1.ScreenSize.X - buttonRadius * 8, Game1.ScreenSize.Y - buttonRadius * 2), buttonRadius, Color.White);
            ButtonChange    = new Button(Graphics.ButtonChange, new Vector2(buttonRadius * 2, Game1.ScreenSize.Y - buttonRadius * 2), buttonRadius, Color.White);

            // ボタンのイベントハンドラの登録
            ButtonUp._begin         = ButtonUp_begin;
            ButtonUp._onPress       = ButtonUp_onPress;
            ButtonUp._end           = ButtonUp_end;
            ButtonRight._begin      = ButtonRight_begin;
            ButtonRight._onPress    = ButtonRight_onPress;
            ButtonRight._end        = ButtonRight_end;
            ButtonDown._begin       = ButtonDown_begin;
            ButtonDown._onPress     = ButtonDown_onPress;
            ButtonDown._end         = ButtonDown_end;
            ButtonLeft._begin       = ButtonLeft_begin;
            ButtonLeft._onPress     = ButtonLeft_onPress;
            ButtonLeft._end         = ButtonLeft_end;
            ButtonChange._begin     = ButtonChange_begin;
            ButtonChange._onPress   = ButtonChange_onPress;
            ButtonChange._end       = ButtonChange_end;

        }

        public override void Update()
        {
            #region タッチの検出

            #region 既存のタッチを更新する
            //上ボタン用のタッチが継続している時
            if (Input.touches.ContainsKey(ButtonUp.touchId))
            {

            }
            else { ButtonUp.touchId = -1; }
            //右ボタン用のタッチが継続している時
            if (Input.touches.ContainsKey(ButtonRight.touchId))
            {

            }
            else { ButtonRight.touchId = -1; }
            //下ボタン用のタッチが継続している時
            if (Input.touches.ContainsKey(ButtonDown.touchId))
            {

            }
            else { ButtonDown.touchId = -1; }
            //左ボタン用のタッチが継続している時
            if (Input.touches.ContainsKey(ButtonLeft.touchId))
            {

            }
            else { ButtonLeft.touchId = -1; }
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
                if (newInfo.Id == ButtonUp.touchId ||
                    newInfo.Id == ButtonRight.touchId ||
                    newInfo.Id == ButtonDown.touchId ||
                    newInfo.Id == ButtonLeft.touchId ||
                    newInfo.Id == ButtonChange.touchId ||
                    newInfo.Id == moveId) continue;
                if (UIManager.oldIds.Contains(newInfo.Id)) continue;
                //新しい上ボタン用タッチを見つけた時
                if (ButtonUp.touchId == -1 && ButtonUp.Pressed(newInfo.Positions[0]))
                {
                    ButtonUp.touchId = newInfo.Id;
                }
                //新しい右ボタン用タッチを見つけた時
                if (ButtonRight.touchId == -1 && ButtonRight.Pressed(newInfo.Positions[0]))
                {
                    ButtonRight.touchId = newInfo.Id;
                }
                //新しい下ボタン用タッチを見つけた時
                if (ButtonDown.touchId == -1 && ButtonDown.Pressed(newInfo.Positions[0]))
                {
                    ButtonDown.touchId = newInfo.Id;
                }
                //新しい左ボタン用タッチを見つけた時
                if (ButtonLeft.touchId == -1 && ButtonLeft.Pressed(newInfo.Positions[0]))
                {
                    ButtonLeft.touchId = newInfo.Id;
                }
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
            #region 上ボタン用タッチの処理
            if (Input.touches.ContainsKey(ButtonUp.touchId))
            {
                switch (Input.touches[ButtonUp.touchId].State)
                {
                    case Input.TouchState.Begin:
                        ButtonUp._begin();
                        break;
                    case Input.TouchState.OnTouch:
                        ButtonUp._onPress();
                        break;
                    case Input.TouchState.End:
                        ButtonUp._end();
                        break;
                }
            }
            #endregion
            #region 右ボタン用タッチの処理
            if (Input.touches.ContainsKey(ButtonRight.touchId))
            {
                switch (Input.touches[ButtonRight.touchId].State)
                {
                    case Input.TouchState.Begin:
                        ButtonRight._begin();
                        break;
                    case Input.TouchState.OnTouch:
                        ButtonRight._onPress();
                        break;
                    case Input.TouchState.End:
                        ButtonRight._end();
                        break;
                }
            }
            #endregion
            #region 下ボタン用タッチの処理
            if (Input.touches.ContainsKey(ButtonDown.touchId))
            {
                switch (Input.touches[ButtonDown.touchId].State)
                {
                    case Input.TouchState.Begin:
                        ButtonDown._begin();
                        break;
                    case Input.TouchState.OnTouch:
                        ButtonDown._onPress();
                        break;
                    case Input.TouchState.End:
                        ButtonDown._end();
                        break;
                }
            }
            #endregion
            #region 左ボタン用タッチの処理
            if (Input.touches.ContainsKey(ButtonLeft.touchId))
            {
                switch (Input.touches[ButtonLeft.touchId].State)
                {
                    case Input.TouchState.Begin:
                        ButtonLeft._begin();
                        break;
                    case Input.TouchState.OnTouch:
                        ButtonLeft._onPress();
                        break;
                    case Input.TouchState.End:
                        ButtonLeft._end();
                        break;
                }
            }
            #endregion
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
            //            if (Input.touches.ContainsKey(moveId))
            //            {
            //                switch (Input.touches[moveId].State)
            //                {
            //                    case Input.TouchState.Begin:
            //                    case Input.TouchState.OnTouch:
            //                        moveDirection = Vector2.Zero;
            //                        break;
            //                    case Input.TouchState.End:
            //#if ANDROID || __IOS__
            //                        double rad = Math.Atan2(Input.touches[moveId].Positions[0].Y - Input.touches[moveId].Positions[Input.MOUSE_DELAY_FRAME - 1].Y, -Input.touches[moveId].Positions[0].X + Input.touches[moveId].Positions[Input.MOUSE_DELAY_FRAME - 1].X);
            //                        double len = Math.Pow(Input.touches[moveId].Positions[0].X - Input.touches[moveId].Positions[Input.MOUSE_DELAY_FRAME - 1].X, 2) + Math.Pow(Input.touches[moveId].Positions[0].Y - Input.touches[moveId].Positions[Input.MOUSE_DELAY_FRAME - 1].Y, 2);
            //                        if (len < 1000)
            //                        {
            //                            moveDirection = Vector2.Zero;
            //                        }
            //                        else
            //                        {
            //                            moveDirection.X = (rad < 3 * Math.PI / 8 && rad > -3 * Math.PI / 8) ? 1 : (rad > 5 * Math.PI / 8 || rad < -5 * Math.PI / 8) ? -1 : 0;
            //                            moveDirection.Y = (rad > -7 * Math.PI / 8 && rad < -1 * Math.PI / 8) ? 1 : (rad > 1 * Math.PI / 8 && rad < 7 * Math.PI / 8) ? -1 : 0;
            //                            VectorArrow.setVisible();
            //                        }
            //                        VectorArrowAngle = -1 * convertAngle(rad);
            //#else
            //                        double rad = Math.Atan2(Input.mouseInfo.Positions[0].Y - Input.mouseInfo.Positions[Input.MOUSE_DELAY_FRAME - 1].Y, -Input.mouseInfo.Positions[0].X + Input.mouseInfo.Positions[Input.MOUSE_DELAY_FRAME - 1].X);
            //                        double len = Math.Pow(Input.mouseInfo.Positions[0].X - Input.mouseInfo.Positions[Input.MOUSE_DELAY_FRAME - 1].X, 2) + Math.Pow(Input.mouseInfo.Positions[0].Y - Input.mouseInfo.Positions[Input.MOUSE_DELAY_FRAME - 1].Y, 2);
            //                        if (len < 100)
            //                        {
            //                            moveDirection = Vector2.Zero;
            //                        }
            //                        else
            //                        {
            //                            moveDirection.X = (rad < 3 * Math.PI / 8 && rad > -3 * Math.PI / 8) ? 1 : (rad > 5 * Math.PI / 8 || rad < -5 * Math.PI / 8) ? -1 : 0;
            //                            moveDirection.Y = (rad > -7 * Math.PI / 8 && rad < -1 * Math.PI / 8) ? 1 : (rad > 1 * Math.PI / 8 && rad < 7 * Math.PI / 8) ? -1 : 0;
            //                            VectorArrow.setVisible();
            //                        }
            //                        VectorArrowAngle = -1 * convertAngle(rad);
            //#endif
            //                        break;
            //                }
            //            }
            #endregion
            #endregion


        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            ButtonUp.Draw(spriteBatch);
            ButtonRight.Draw(spriteBatch);
            ButtonDown.Draw(spriteBatch);
            ButtonLeft.Draw(spriteBatch);
            ButtonChange.Draw(spriteBatch);
        }

        #region ボタンのイベントハンドラ
        public void ButtonUp_begin()
        {
            ButtonUp.isPressed = true;
        }
        public void ButtonUp_onPress()
        {
            Game1.namazu.move(new Vector2(0, -1));
        }
        public void ButtonUp_end()
        {
            ButtonUp.isPressed = false;
        }
        public void ButtonRight_begin()
        {
            ButtonRight.isPressed = true;
        }
        public void ButtonRight_onPress()
        {
            Game1.namazu.move(new Vector2(1, 0));
        }
        public void ButtonRight_end()
        {
            ButtonRight.isPressed = false;
        }
        public void ButtonDown_begin()
        {
            ButtonDown.isPressed = true;
        }
        public void ButtonDown_onPress()
        {
            Game1.namazu.move(new Vector2(0, 1));
        }
        public void ButtonDown_end()
        {
            ButtonDown.isPressed = false;
        }
        public void ButtonLeft_begin()
        {
            ButtonLeft.isPressed = true;
        }
        public void ButtonLeft_onPress()
        {
            Game1.namazu.move(new Vector2(-1, 0));
        }
        public void ButtonLeft_end()
        {
            ButtonLeft.isPressed = false;
        }
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
            UIManager.NextUI = UIManager.UIType.Touch;
        }
        #endregion



    }
}
