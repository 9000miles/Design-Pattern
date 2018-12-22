//-------------------------------------------------------------------------------------
//	ComponentPatternExample.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ComponentPatternExample
{
    public class ComponentPatternExample : MonoBehaviour
    {
        private RPGGame rpgGame = new RPGGame();

        private void Start()
        {
            rpgGame.Start();
        }

        private void Update()
        {
            rpgGame.Update();
        }
    }

    /// <summary>
    /// 游戏类
    /// </summary>
    internal class RPGGame
    {
        public int velocity;
        public int x = 0, y = 0;

        //辅助类对象
        public WorldX worldX = new WorldX();
        public GraphicsX graphicsX = new GraphicsX();

        //组件
        private InputComponent inputComponent;
        private PhysicsComponent physicsComponent;
        private GraphicsComponent graphicsComponent;

        //组件List
        public List<BaseComponent> ComponentList = new List<BaseComponent>();
        //组件List容量
        private int componentAmount = -1;

        public void Start()
        {
            inputComponent = new PlayerInputComponent();
            physicsComponent = new PlayerPhysicsComponent();
            graphicsComponent = new PlayerGraphicsComponent();

            ComponentList.Add(inputComponent);
            ComponentList.Add(physicsComponent);
            ComponentList.Add(graphicsComponent);

            Debug.Log("Game Components Initialization Finish...");
            Debug.Log("Please enter LeftArrow or RightArrow button to play...");
        }

        public void Update()
        {
            if (ComponentList == null)
            {
                return;
            }
            componentAmount = ComponentList.Count;
            for (int i = 0; i < componentAmount; i++)
            {
                ComponentList[i].Update(this);
            }
        }
    };

    /// <summary>
    /// 输入组件
    /// </summary>
    internal class PlayerInputComponent : InputComponent
    {
        public void Update(RPGGame game)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                game.velocity -= WALK_ACCELERATION;
                Debug.Log(" game velocity= " + game.velocity.ToString());
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                game.velocity += WALK_ACCELERATION;
                Debug.Log(" game velocity= " + game.velocity.ToString());
            }
        }

        private int WALK_ACCELERATION = 1;
    }

    /// <summary>
    /// 物理组件
    /// </summary>
    internal class PlayerPhysicsComponent : PhysicsComponent
    {
        public void Update(RPGGame game)
        {
            game.x += game.velocity;

            //Handle Physics...
        }
    }

    /// <summary>
    /// 图形组件
    /// </summary>
    internal class PlayerGraphicsComponent : GraphicsComponent
    {
        public void Update(RPGGame game)
        {
            //Handle Graphics...

            if (game == null || game.graphicsX == null)
            {
                return;
            }

            Sprite sprite = spriteStand;
            if (game.velocity < 0)
            {
                sprite = spriteWalkLeft;
            }
            else if (game.velocity > 0)
            {
                sprite = spriteWalkRight;
            }
            game.graphicsX.Draw(sprite, game.x, game.y);
        }

        private Sprite spriteStand;
        private Sprite spriteWalkLeft;
        private Sprite spriteWalkRight;
    }

    #region interfaces

    internal interface BaseComponent
    {
        void Update(RPGGame game);
    }

    internal interface GraphicsComponent : BaseComponent
    {
        new void Update(RPGGame game);
    }

    internal interface PhysicsComponent : BaseComponent
    {
        new void Update(RPGGame game);
    }

    internal interface InputComponent : BaseComponent
    {
        new void Update(RPGGame game);
    }

    #endregion interfaces

    #region 辅助类

    internal class WorldX
    {
    }

    internal class GraphicsX
    {
        public void Draw(Sprite sprite, float x, float y)
        {
        }
    }
}

#endregion 辅助类