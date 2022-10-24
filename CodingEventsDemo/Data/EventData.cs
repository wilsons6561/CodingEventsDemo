using CodingEventsDemo.Models;
using System.Collections.Generic;

namespace CodingEventsDemo.Data
{
    public class EventData
    {
        // store events
        private static Dictionary <int, Event> Events = new Dictionary<int, Event>();
        // add events
        public static void Add(Event newEvent)
        {
            Events.Add(newEvent.Id, newEvent);
        }
        //retrieve the events
        public static IEnumerable<Event> GetAll()
        {
            return Events.Values;
        }

        // retrieve a single event
        public static Event GetById(int Id)
        {
            return Events[Id];
        }
        // remove an event
        public static void Remove(int id)
        {
            Events.Remove(id);
        }
    }
}
