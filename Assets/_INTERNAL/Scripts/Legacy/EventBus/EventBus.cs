using System;
using System.Collections.Generic;

namespace EventBus
{
    public class EventBus<T>
    {
        private static readonly Dictionary<GameEventEnum, Action<T>> _eventHandlers = new();

        public static void Subscribe(GameEventEnum eventType, Action<T> action)
        {
            if (_eventHandlers.ContainsKey(eventType))
            {
                _eventHandlers[eventType] += action;
            }
            else
            {
                _eventHandlers[eventType] = action;
            }
        }

        public static void Unsubscribe(GameEventEnum eventType, Action<T> action)
        {
            if (_eventHandlers.ContainsKey(eventType))
            {
                _eventHandlers[eventType] -= action;
                if (_eventHandlers[eventType] == null)
                {
                    _eventHandlers.Remove(eventType);
                }
            }
        }

        public static void Publish(GameEventEnum eventType, T payload)
        {
            if (_eventHandlers.ContainsKey(eventType))
            {
                _eventHandlers[eventType]?.Invoke(payload);
            }
        }
    }
}