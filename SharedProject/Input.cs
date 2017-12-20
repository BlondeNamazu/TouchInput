using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace SharedProject
{
    static class Input
    {
        // 座標を保持するフレーム数
        public static readonly int DELAY_FRAME = 10;

        // タッチ入力
        public static TouchCollection touchCollection;
        public static TouchLocation dummyLocation = new TouchLocation();

        // 入力を扱いやすい形で保存する
        public enum TouchState
        {
            Begin,
            OnTouch,
            End
        }

        //一つのIDに対応するタッチの情報を保持するクラス
        public class TouchInfo
        {
            public int Id;
            public Vector2[] Positions;
            public TouchState State, lastState;

            public TouchInfo(TouchLocation location)
            {
                this.Id = location.Id;
                this.Positions = new Vector2[DELAY_FRAME];
                for (int i = 0; i < DELAY_FRAME; i++)
                {
                    this.Positions[i] = location.Position;
                }
                this.State = TouchState.Begin;
            }
            public void Update(TouchLocation location)
            {
                lastState = State;
                for (int i = DELAY_FRAME - 1; i > 0; i--)
                {
                    this.Positions[i] = this.Positions[i - 1];
                }
                this.Positions[0] = location.Position;
                switch (location.State)
                {
                    case TouchLocationState.Invalid:
                    case TouchLocationState.Released:
                        {
                            this.State = TouchState.End;
                            break;
                        }
                    case TouchLocationState.Pressed:
                        {
                            this.State = TouchState.Begin;
                            break;
                        }
                    case TouchLocationState.Moved:
                        {
                            this.State = TouchState.OnTouch;
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        // アクティブなタッチ情報を保存しておくDictionary
        public static ConcurrentDictionary<int, TouchInfo> touches;

        public static void Init()
        {
            touches = new ConcurrentDictionary<int, TouchInfo>();
        }

        public static void Update()
        {
            touchCollection = TouchPanel.GetState();

            // 古いタッチ情報をtouchesから削除
            if (touches.Count > 0)
            {
                foreach (int id in touches.Keys)
                {
                    if (!touchCollection.FindById(id, out dummyLocation))
                    {
                        if (touches[id].State == TouchState.End)
                        {
                            TouchInfo dummyInfo;
                            touches.TryRemove(id, out dummyInfo);
                        }
                        else
                        {
                            touches[id].State = TouchState.End;
                        }
                    }
                }
            }

            // 新しいタッチ情報をtouchesに追加、継続しているタッチ情報を更新
            foreach (TouchLocation location in touchCollection)
            {
                if (touches.ContainsKey(location.Id))
                {
                    touches[location.Id].Update(location);
                }
                else
                {
                    touches.TryAdd(
                        location.Id,
                        new TouchInfo(location)
                    );
                }
            }
            foreach (int id in touches.Keys)
            {
                if (!touchCollection.FindById(id, out dummyLocation))
                {
                    if (touches[id].State == TouchState.End)
                    {
                        TouchInfo dummyInfo;
                        touches.TryRemove(id, out dummyInfo);
                    }
                    else
                    {
                        touches[id].State = TouchState.End;
                    }
                }
                Console.WriteLine(touches[id].Positions[0].ToString());
            }
        }
    }
}
