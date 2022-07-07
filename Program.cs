// See https://aka.ms/new-console-template for more information
//
//Console.WriteLine("Hello, World!");

/*
Immaginate di lavorare in una software house, che ha diversi clienti. Vi è stato commissionato da parte della vostra azienda la creazione di un 
gestionale eventi per eventi come concerti, conferenze, spettacoli,… per un suo cliente. 
Il cliente necessita di un semplice programma senza interfaccia grafica (ossia che venga eseguito in console o terminale) che si occupa di:

Memorizzare e tenere traccia di tutti gli eventi in futuro che ha programmato

Poter gestire le prenotazioni e le disdette delle sue conferenze e tenere traccia quindi dei posti prenotati e di quelli disponibili per un dato evento

Poter gestire un intero programma di Eventi (ossia tenere traccia di tutti gli eventi che afferiscono ad serie di Conferenze)
*/

// create a new program
EventProgram eventsSchedule = CreateEventsProgram();

AddEventsToProgram();




// method that create a new EventProgram with title
EventProgram CreateEventsProgram()
{
    Console.WriteLine("Let's create YOUR program of events!");
    Thread.Sleep(1000);
    Console.Clear();

    Console.Write("First of all, let's give it a name: ");
    string programTitle = Console.ReadLine();

    EventProgram newProgram;
    try
    {
        return newProgram = new EventProgram(programTitle);
    }
    catch (ArgumentNullException)
    {
        Console.WriteLine("Invalid title, try to write normally! ;)");
        return CreateEventsProgram();
    }
}


// method that add new event in the program
void AddEventsToProgram()
{
    try
    {
        Console.Write("How many event do you want to add? ");
        int n = int.Parse(Console.ReadLine());
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine($"Number of event to add: {n}");

        for (int i = 0; i < n; i++)
        {
            // create a new event
            Event newEvent = CreateEvent();

            Console.WriteLine();
            Console.WriteLine("***** Get you reservation now! *****");
            Console.WriteLine();

            // make reservation
            Reservations(newEvent);

            // cancelling seats
            Cancellation(newEvent);

            // 
            eventsSchedule.ListToString();
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Not valid, try with a simple number! ;)");
        Thread.Sleep(1000);
        Console.Clear();
        AddEventsToProgram();
    }
}



// method that create a new Event class
Event CreateEvent()
{
    Console.WriteLine("Event Creation");
    Console.WriteLine();

    Console.Write("Insert the event name: ");
    string title = (string)Console.ReadLine().ToLower();

    Console.Write("Insert event date (dd/mm/yyyy): ");
    DateTime date = DateTime.Parse(Console.ReadLine());

    Console.Write("Maximum capacity of the event: ");
    int capacity = int.Parse(Console.ReadLine());
    Event newEvent;
    try
    {
         newEvent = new Event(title, date, capacity);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
        newEvent = CreateEvent();
    }

    return newEvent;
}


// method that takes an obj as param and set the number of reservation
// recalling the Event method GetReservation();
void Reservations(Event newEvent)
{
    Console.WriteLine("Do you want to reserved some seats?	( yes / no )");
    string userInput = Console.ReadLine().ToLower();

    if (userInput == "yes" || userInput == "si")
    {
        Console.WriteLine();
        Console.WriteLine("How many seats you want to reserve?");
        int reserve = int.Parse(Console.ReadLine());
        try
        {
            newEvent.GetReservation(reserve);
        }
        catch
        {
            Reservations(newEvent);
        }

        newEvent.PrintReservation();
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("You will miss a beautiful event..");

        Thread.Sleep(2000);

        Console.WriteLine();
        Console.WriteLine("Are you shure?	( yes / no )");

        string userConferm = Console.ReadLine().ToLower();

        if (userConferm == "no")
        {
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("Nice to see you again!");
            Reservations(newEvent);
        }
        else
        {
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("Fine, then farewell...");
        }

    }
}


// method that takes an obj as param and set the number of cancellations
// recalling the Event method CancelReservation();
void Cancellation(Event newEvent)
{
    Console.WriteLine("Do you want to cancel some reservation?	( yes / no )");
    string userInput = Console.ReadLine().ToLower();

    if (userInput == "yes" || userInput == "si")
    {
        Console.WriteLine("How many seats do you want to cancel?");
        int cancel = int.Parse(Console.ReadLine());
        try
        {
            newEvent.CancelReservation(cancel);
        }
        catch
        {
            Cancellation(newEvent);
        }

        newEvent.PrintReservation();
    }
    else
    {
        Console.WriteLine("Yeah! I see you've changed your mind, actually it's a great event! ");

        Thread.Sleep(2000);

        Console.WriteLine("But, after all, are you shure that you wanna go?	( yes / no )");

        string userConferm = Console.ReadLine().ToLower();

        if (userConferm == "no")
        {
            Console.WriteLine("I knew it...");
            Cancellation(newEvent);
        }
        else
        {
            Console.WriteLine("That's the spirit!");
        }

    }
}