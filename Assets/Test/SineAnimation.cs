using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Oojfwe
{
    private void ofoe()
    {
        string str = "";
    }
}

public class SineAnimation : MonoBehaviour, IScrollHandler
{
    public const string run = "un";
    public readonly string[] ojfowe;
    public readonly string walk = "Wlk";
    private PointerEventData eventData;

    public SineAnimation()
    {
        ojfowe = new string[] { "5858", "92fewf" };
    }

    private void Start()
    {
        ojfowe[0] = "jojfoweojfowejo";
        foreach (var item in ojfowe)
        {
            Debug.Log(item);
        }
        eventData = new PointerEventData(EventSystem.current);
    }

    public void OnScroll(PointerEventData eventData)
    {
        Debug.Log(eventData.scrollDelta);
    }

    public Vector3 axis { get { return m_Axis; } set { m_Axis = value; } }
    [SerializeField]
    private Vector3 m_Axis = Vector3.up;

    public float period { get { return m_Period; } set { m_Period = value; } }
    [SerializeField]
    private float m_Period = 1f / Mathf.PI;

    public float amplitude { get { return m_Amplitude; } set { m_Amplitude = value; } }
    [SerializeField]
    private float m_Amplitude = 1f;

    public float phaseShift { get { return m_PhaseShift; } set { m_PhaseShift = Mathf.Clamp01(value); } }
    [SerializeField, Range(0f, 1f)]
    private float m_PhaseShift;

    private void Update()
    {
        transform.localPosition = m_Axis * m_Amplitude * Mathf.Sin((Time.time + m_PhaseShift) / m_Period);
    }

    private void OnGUI()
    {
        //OnScroll(eventData);
        Event e = Event.current;
        //Debug.Log(e.character);
        //Debug.Log(e.keyCode);
        //if (e.isMouse && e.clickCount == 1)
        //{
        //    Debug.Log(e.button);
        //}
        //Debug.Log(e.type);
        Debug.Log(e.pressure);
    }

    private void OnValidate()
    {
        m_PhaseShift = Mathf.Clamp01(m_PhaseShift);
    }
}