
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PressHandler : MonoBehaviour, IPointerDownHandler
{
    [Serializable]
    public class ButtonPressEvent : UnityEvent
    {

    }

    public ButtonPressEvent OnPress = new ButtonPressEvent();

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPress.Invoke();
    }
}
