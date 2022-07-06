using System;

public class Event
{
	public string EventTitle 
	{
        get
		{
			return EventTitle;	
		}
        set
        {
			EventTitle = value;

			if (value.Length == 0)
			{
				throw new ArgumentException("This field can't be empty...");
			}
		} 
	}
	public DateTime Date
	{
		get
		{
			return Date;
		}
		set
		{
			Date = value;
			DateTime now = DateTime.Now;
			//Date.Day && Date.Month && Date.Year <= now.Day && now.Month && now.Year
			if (Date < now.Date)
            {
				throw new Exception("This event has already been done...");
			}
			else if (Date == now.Date)
            {
				throw new Exception("The Event is today!");
            }
		}
	}
	public uint MaxSeats 
	{
		get 
		{
			return MaxSeats;
		}
		private set 
		{
			MaxSeats = value;
			try
			{
				if(MaxSeats is uint)
                {
					MaxSeats = (uint)MaxSeats;
                }
			}
			catch (Exception)
			{
				Console.WriteLine("Invalid input, number of seats must be positive...");
			}
		} 
	}
	public int ReservedSeats { get; private set; }

	public Event(string title, DateOnly date, uint maxSeats, int reservedSeats = 0)
	{
		this.EventTitle = title;
		this.Date = Date;
		this.MaxSeats = maxSeats;
		this.ReservedSeats = reservedSeats;
	}

	public void GetReservation()
    {
		
    }

	public void CancelReservation()
    {

    }
}
