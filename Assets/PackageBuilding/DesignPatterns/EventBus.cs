using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Cobra.DesignPattern
{
    public class EventBus
    {
        List<UnityAction<EventSubscriberArgs>> conglomerate = new List<UnityAction<EventSubscriberArgs>>();
        public EventBus()
        {
        }
        
        public void AddListener(UnityAction<EventSubscriberArgs> method)
        {
            conglomerate.Add(method);
        }

        public void RemoveListener(UnityAction<EventSubscriberArgs> method)
        {
            conglomerate.Remove(method);
        }

        public void Invoke(EventSubscriberArgs args)
        {
            for(int i = Count - 1; i >= 0; i--) conglomerate[i].Invoke(args);
        }
        public void Invoke() => Invoke(null);
        public int Count => conglomerate.Count;
        public void Clear() => conglomerate.Clear();
    }

    public class EventBusDictionary
    {
        public void AddListener(string eventID, UnityAction<EventSubscriberArgs> method)
        {
            GetEventService(eventID).AddListener(method);
        }

        public void RemoveListener(string eventID, UnityAction<EventSubscriberArgs> method)
        {
            GetEventService(eventID).RemoveListener(method);
        }
        public void Invoke(string eventID, EventSubscriberArgs args = null)
        {
            GetEventService(eventID).Invoke(args);
        }

        public int Count(string eventID)
        {
            return GetEventService(eventID).Count;
        }
        public int Total => map.Count;
        public int Entries => map.Keys.Count;
        private Dictionary<string, EventBus> map = new Dictionary<string, EventBus>();

        private bool HasEventID(string eventID)
        {
            return map.ContainsKey(eventID);
        }

        private EventBus GetEventService(string eventID)
        {
            if(HasEventID(eventID)) return map[eventID];
            map.Add(eventID, new EventBus());
            return map[eventID];
        }
    }

    public class EventSubscriberArgs
    {
    }
}