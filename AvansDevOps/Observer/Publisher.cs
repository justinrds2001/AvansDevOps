using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Observer
{
    public abstract class Publisher
    {
        private List<ISubscriber> _subscribers = new List<ISubscriber>();

        // Method to subscribe a participant
        public void Subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
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
    }
}
