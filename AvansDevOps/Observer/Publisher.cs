﻿using AvansDevOps.Observer.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Observer
{
    public abstract class Publisher
    {
        private readonly List<ISubscriber> _subscribers = new List<ISubscriber>();

        // Method to subscribe a participant
        public void Subscribe(ISubscriber subscriber)
        {
            if (!_subscribers.Contains(subscriber))
            {
                _subscribers.Add(subscriber);
            }
        }

        // Method to unsubscribe a participant
        public void Unsubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        // Method to notify all subscribers
        public void Notify(string message)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(message);
            }
        }

        public void NotifySpecificParticipant<T>(string message)
        {
            foreach (var subscriber in _subscribers)
            {
                if (subscriber.GetType() == typeof(T))
                {
                    subscriber.Update(message);
                }
            }
        }
    }
}
