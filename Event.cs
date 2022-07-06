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

	public void GetReservation(int reservedUser)
    {
        Console.WriteLine("How many seats you want to reserve?");
		reservedUser = int.Parse(Console.ReadLine());

		if(reservedUser <= 0)
        {
			throw new Exception("Invalid input, number of reservations must be positive...");
        }
		else if(Date < DateTime.Now)
        {
			throw new Exception("Not possible reserved seats for an event of the past!");
        }
        else if(this.ReservedSeats == this.MaxSeats)
        {
			throw new Exception("Sorry, we're out of seats!");
		}
		else
        {
			this.ReservedSeats += reservedUser;
		}
    }

	public void CancelReservation(int cancelReserved)
    {
        Console.WriteLine("How many seats do you want to cancel?");
		cancelReserved = int.Parse(Console.ReadLine());

		if(Date < DateTime.Now)
        {
			throw new Exception("Not possible cancel seats for an event of the past!");
        }
		else if (cancelReserved > ReservedSeats)
        {
			throw new Exception("Not possibile cancel more seats than already reserved...");
        }
		else
        {
			cancelReserved -= ReservedSeats;
        }
    }

    public override string ToString()
    {
		return $"{this.Date.ToString("dd/MM/yyyy")} - {EventTitle}";
    }
}
