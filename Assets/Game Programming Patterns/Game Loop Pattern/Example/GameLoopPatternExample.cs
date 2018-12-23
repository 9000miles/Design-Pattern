//-------------------------------------------------------------------------------------
//	GameLoopPatternExample.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace GameLoopPatternExample
{
    public class GameLoopPatternExample : MonoBehaviour
    {
        private GameLoopManager GameLoop = new GameLoopManager();

        private void Start()
        {
            //进行游戏循环
            //DoGameLoop();
            Debug.Log("Unity已经内建了游戏循环模式，即Update( )，按《游戏编程模式》书中的原版实现会导致卡死。这边仅保留代码框架，不作调用。");
            DoGameLoop();
        }

        private void Update()
        {
        }

        /// <summary>
        /// 进行游戏循环
        /// </summary>
        private void DoGameLoop()
        {
            if (GameLoop == null)
            {
                GameLoop = new GameLoopManager();
            }

            GameLoop.DoGameLoop();
        }
    }

    /// <summary>
    /// 游戏循环manager
    /// </summary>
    public class GameLoopManager
    {
        /// <summary>
        /// 游戏更新的粒度
        /// </summary>
        public const float MS_PER_UPDATE = 0.06F;

        /// <summary>
        /// 进行游戏循环
        /// </summary>
        public void DoGameLoop()
        {
            double previous = Time.realtimeSinceStartup;
            double lag = 0.0;
            if (Time.realtimeSinceStartup == 0f)
            {
                return;
            }
            while (true)
            {
                //当前时间
                double current = Time.realtimeSinceStartup;
                //消逝的时间
                double elapsed = current - previous;
                previous = current;
                lag += elapsed;
                ProcessInput();

                while (lag >= MS_PER_UPDATE)
                {
                    Update();
                    lag -= MS_PER_UPDATE;
                }

                if (Time.realtimeSinceStartup >= 1000f)
                    return;

                Render();
            }
        }

        /// <summary>
        /// 处理按键消息
        /// </summary>
        private void ProcessInput()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("[GameLoopManager]你按下了键盘1键！");
            }
        }

        /// <summary>
        /// 进行渲染
        /// </summary>
        private void Render()
        {
            //do render
        }

        /// <summary>
        /// 处理更新
        /// </summary>
        private void Update()
        {
            //do update
        }
    }
}