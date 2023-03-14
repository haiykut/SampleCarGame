using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace haiykut
{
    public class HoverEffect : MonoBehaviour
    {
        public HoverEffectSettings settings;
        void Start()
        {

            EventTrigger eventTrigger = gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry onPointerEnter = new EventTrigger.Entry();
            EventTrigger.Entry onPointerExit = new EventTrigger.Entry();
            onPointerEnter.eventID = EventTriggerType.PointerEnter;
            onPointerExit.eventID = EventTriggerType.PointerExit;
            onPointerEnter.callback.AddListener((pointerEventData) => { OnPointerEnter((PointerEventData)pointerEventData); });
            onPointerExit.callback.AddListener((pointerEventData) => { OnPointerExit((PointerEventData)pointerEventData); });
            eventTrigger.triggers.Add(onPointerEnter);
            eventTrigger.triggers.Add(onPointerExit);
            if (settings.button)
            {
                transform.GetComponentInChildren<Text>().fontSize = settings.initialSize;
                transform.GetComponentInChildren<Text>().color = settings.initialColor;
            }
            else
            {
                transform.GetComponent<Text>().fontSize = settings.initialSize;
                transform.GetComponent<Text>().color = settings.initialColor;
            }

        }
        void OnPointerEnter(PointerEventData pointerEventData)
        {
            Hover();
        }

        void OnPointerExit(PointerEventData pointerEventData)
        {
            Exit();
        }
        void Hover()
        {
            switch (settings.effect)
            {
                case HoverEffectSettings.Effect.Scale:
                    switch (settings.button)
                    {
                        case true:
                            transform.GetComponentInChildren<Text>().fontSize = settings.hoverSize;
                            break;
                        case false:
                            transform.GetComponent<Text>().fontSize = settings.hoverSize;
                            break;
                    }
                    break;
                case HoverEffectSettings.Effect.Color:
                    switch (settings.button)
                    {
                        case true:
                            transform.GetComponentInChildren<Text>().color = settings.hoverColor;
                            break;
                        case false:
                            transform.GetComponent<Text>().color = settings.hoverColor;
                            break;
                    }
                    break;
                case HoverEffectSettings.Effect.ScaleAndColor:
                    switch (settings.button)
                    {
                        case true:
                            transform.GetComponentInChildren<Text>().fontSize = settings.hoverSize;
                            transform.GetComponentInChildren<Text>().color = settings.hoverColor;
                            break;
                        case false:
                            transform.GetComponent<Text>().fontSize = settings.hoverSize;
                            transform.GetComponent<Text>().color = settings.hoverColor;
                            break;
                    }
                    break;


            }

        }
        void Exit()
        {
            switch (settings.effect)
            {
                case HoverEffectSettings.Effect.Scale:
                    switch (settings.button)
                    {
                        case true:
                            transform.GetComponentInChildren<Text>().fontSize = settings.initialSize;
                            break;
                        case false:
                            transform.GetComponent<Text>().fontSize = settings.initialSize;
                            break;
                    }
                    break;
                case HoverEffectSettings.Effect.Color:
                    switch (settings.button)
                    {
                        case true:
                            transform.GetComponentInChildren<Text>().color = settings.initialColor;
                            break;
                        case false:
                            transform.GetComponent<Text>().color = settings.initialColor;
                            break;
                    }
                    break;
                case HoverEffectSettings.Effect.ScaleAndColor:
                    switch (settings.button)
                    {
                        case true:
                            transform.GetComponentInChildren<Text>().fontSize = settings.initialSize;
                            transform.GetComponentInChildren<Text>().color = settings.initialColor;
                            break;
                        case false:
                            transform.GetComponent<Text>().fontSize = settings.initialSize;
                            transform.GetComponent<Text>().color = settings.initialColor;
                            break;
                    }
                    break;

            }
        }

    }
}
