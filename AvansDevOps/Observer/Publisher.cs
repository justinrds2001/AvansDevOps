using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Observer
{
    public abstract class Publisher
    {
        private readonly List<ISubsriber> _subscribers = new();

        // add subscriber method
        public void Subscribe(ISubsriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        // remove subscriber method
        public void Unsubscribe(ISubsriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        // notify subscribers method
        public void NotifySubscribers()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Notify();
            }
        }
    }
}
