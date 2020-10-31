using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;


[System.Serializable] public class EnhancedEvent : UnityEvent<string> { }


public class EventManager : MonoBehaviour
{

    Dictionary<string, EnhancedEvent> eventDictionary;

    static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, EnhancedEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction<string> listener)
    {
        EnhancedEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new EnhancedEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction<string> listener)
    {
        if (eventManager == null) return;
        EnhancedEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName,string json)
    {
        EnhancedEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(json);
        }
    }
}