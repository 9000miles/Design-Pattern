//-------------------------------------------------------------------------------------
//	EventQueue.cs
// Reference :https://github.com/GandhiGames/message_queue
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EventQueuePatternExample
{
    public class EventQueue : MonoBehaviour
    {
        #region 事件队列相关

        /// <summary>
        /// 队列中待投递的事件队列
        /// </summary>
        private List<IMessageEvent> pendingEventQueueList = new List<IMessageEvent>();

        /// <summary>
        /// 事件投递函数
        /// </summary>
        private void OnAddEventToQueue(IMessageEvent e)
        {
            pendingEventQueueList.Add(e);

            if (logToConsole)
            {
                Debug.Log("Message Recieved [" + System.DateTime.Now + "]: " + e.Message.ToString());
            }
        }

        private void Update()
        {
            for (int i = pendingEventQueueList.Count - 1; i >= 0; i--)
            {
                if (Time.time > pendingEventQueueList[i].DisplayTime)
                    pendingEventQueueList.RemoveAt(i);
            }
        }

        private void Start()
        {
            if (pendingEventQueueList.Count > 0)
            {
                pendingEventQueueList.Clear();
            }

            EventQueueManager.Instance.AddListener<MessageEvent>(OnAddEventToQueue);
        }

        private void OnDisable()
        {
            EventQueueManager.Instance.RemoveListener<MessageEvent>(OnAddEventToQueue);
        }

        #endregion 事件队列相关

        #region UI显示相关

        private void OnEnable()
        {
            SetUIStyle();
        }

        private void SetUIStyle()
        {
            LOW_PRIORTY.normal.textColor = lowPriorityColour;
            LOW_PRIORTY.fontStyle = lowPriorityStyle;

            NORMAL_PRIORITY.normal.textColor = normalPriorityColour;
            NORMAL_PRIORITY.fontStyle = normalPriorityStyle;

            HIGH_PRIORITY.normal.textColor = highPriorityColour;
            HIGH_PRIORITY.fontStyle = highPriorityStyle;
        }

        public bool logToConsole = true;
        public bool prependDateTime = false;

        [Header("Message Colours")]
        public Color highPriorityColour = Color.red;
        public Color normalPriorityColour = Color.black;
        public Color lowPriorityColour = Color.white;

        [Header("Message Font Style")]
        public FontStyle highPriorityStyle = FontStyle.Bold;
        public FontStyle normalPriorityStyle = FontStyle.Normal;
        public FontStyle lowPriorityStyle = FontStyle.Normal;

        [Header("Message Location")]
        public Vector2 queueLocation = new Vector2(25, 25);
        public Vector2 messageSize = new Vector2(200, 15);

        private static readonly GUIStyle LOW_PRIORTY = new GUIStyle(), NORMAL_PRIORITY = new GUIStyle(), HIGH_PRIORITY = new GUIStyle();

        private void OnGUI()
        {
            float yPos = queueLocation.y;

            foreach (var m in pendingEventQueueList)
            {
                GUIStyle style = GetMessageStyle(m);

                string message = (prependDateTime) ? "[" + m.TimeRaised + "]: " + m.Message.ToString() : m.Message.ToString();

                GUI.Label(new Rect(queueLocation.x, yPos, messageSize.x, messageSize.y), message, style);

                yPos += messageSize.y;
            }
        }

        private GUIStyle GetMessageStyle(IMessageEvent e)
        {
            switch (e.Priority)
            {
                case MessagePriority.Low:
                    return LOW_PRIORTY;
                case MessagePriority.Medium:
                    return NORMAL_PRIORITY;
                default:
                    return HIGH_PRIORITY;
            }
        }

        #endregion UI显示相关
    }
}