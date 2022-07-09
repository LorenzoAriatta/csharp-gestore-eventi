using System;

public class Event
{
	private string title;
	private DateTime date;
	private int maxSeats;
	public string EventTitle 
	{
        get
		{
			return this.title;	
		}
        set
        {
			this.title = value;

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
			return this.date;
		}
		set
		{
			this.date = value;
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
	public int MaxSeats 
	{
		get 
		{
			return this.maxSeats;
		}
		private set 
		{
			this.maxSeats = value;

			if(value <= 0)
            {
				throw new Exception("Invalid input, number of seats must be positive...");
            }
		} 
	}
	public int ReservedSeats { get; private set; }

	public Event(string title, DateTime date, int maxSeats, int reservedSeats = 0)
	{
		this.EventTitle = title;
		this.Date = date;
		this.MaxSeats = maxSeats;
		this.ReservedSeats = reservedSeats;
	}

	public void GetReservation(int reservedUser)
    {
		if (reservedUser <= 0)
		{
			throw new Exception("Invalid input, number of reservations must be positive...");
		}
		else if (Date < DateTime.Now)
		{
			throw new Exception("Not possible reserved seats for an event of the past!");
		}
		else if (this.ReservedSeats + reservedUser == this.MaxSeats)
		{
			throw new Exception("Sorry, we're out of seats! Try with a small amount");
		}
		else
		{
			this.ReservedSeats += reservedUser;
		}
    }

	public void CancelReservation(int cancelReserved)
    {
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
		return $"{this.Date.ToString("dd/MM/yyyy")} - {this.title}";
    }

	public void PrintReservation()
    {
        Console.WriteLine($"Number of seats reserved: {this.ReservedSeats} | Seats remains: {this.maxSeats - this.ReservedSeats}");
    }
}
