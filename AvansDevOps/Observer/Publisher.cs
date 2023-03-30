using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Observer
{
    public abstract class Publisher
    {
        public List<ISubsriber> Subscribers { get; set; }

        // add subscriber method
        public void Subscribe(ISubsriber subscriber)
        {
            Subscribers.Add(subscriber);
        }

        // remove subscriber method
        public void Unsubscribe(ISubsriber subscriber)
        {
            Subscribers.Remove(subscriber);
        }

        // notify subscribers method
        public void NotifySubscribers()
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.Notify();
            }
        }
    }
}
