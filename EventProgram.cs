using System;

public class EventProgram
{
	public string Title { get; set; }
	List<Event> events;
	public EventProgram(string title)
	{
		this.Title = title;
		events = new List<Event>();
	}

	public void AddEventToList(Event eventToAdd)
    {
		events.Add(eventToAdd);
        Console.WriteLine("Added to list!");
    }

	public List<Event> SearchEventByDate(DateTime date)
    {
		List<Event> filter = new List<Event>();
		foreach(Event filteredEvent in events)
        {
			if(filteredEvent.Date == date)
            {
				filter.Add(filteredEvent);
            }
        }
		return filter;
    }

	public static string StampList(List<Event> events)
    {
		if(events.Count == 0)
        {
            Console.WriteLine("No events in list...");
        }

		string toStamp = "";

		foreach(Event eventsToStamp in events)
        {
			toStamp =  $"{eventsToStamp.Date.ToString("dd/mm/yyyy")} - {eventsToStamp.EventTitle}";
        }

		return toStamp;
    }

	public string CountEvents()
    {
		return $"There are {events.Count()} scheduled events!";
    }

	public void ClearList()
    {
		Console.WriteLine("ATTENTION! With this method you will delete ALL events.");
        Console.WriteLine();

		Thread.Sleep(1000);
        Console.WriteLine("So, you REALLY want delete ALL events?	( yes / no )");
		string confirm = Console.ReadLine().ToLower();

		if(confirm == "yes")
        {
			events.Clear();
        }
        else
        {
            Console.WriteLine($"So close!");
        }

	}

	public string ListToString()
    {
		return $"{this.Title}\n{EventProgram.StampList(this.events)}";
    }
}
