using System;
using System.Collections.Generic;

namespace Task2
{
    public static class Task2
    {
        public static void Run()
        {
            var runway1 = new Runway();
            var runway2 = new Runway();

            var aircraft1 = new Aircraft("Boeing 737");
            var aircraft2 = new Aircraft("Airbus A320");

            var center = new CommandCentre(
                new Runway[] { runway1, runway2 },
                new Aircraft[] { aircraft1, aircraft2 }
            );

            aircraft1.RequestLanding();
            aircraft2.RequestLanding();

            aircraft1.RequestTakeOff();
        }
    }

    // MEDIATOR 
    class CommandCentre
    {
        private List<Runway> _runways = new List<Runway>();

        // Aircraft -> Runway
        private Dictionary<Aircraft, Runway> _aircraftRunways =
            new Dictionary<Aircraft, Runway>();

        public CommandCentre(Runway[] runways, Aircraft[] aircrafts)
        {
            _runways.AddRange(runways);

            foreach (var aircraft in aircrafts)
            {
                aircraft.SetMediator(this);
            }
        }

        public void RequestLanding(Aircraft aircraft)
        {
            Console.WriteLine($"\nLanding request from {aircraft.Name}");

            foreach (var runway in _runways)
            {
                if (!runway.IsBusy)
                {
                    runway.IsBusy = true;

                    _aircraftRunways[aircraft] = runway;

                    Console.WriteLine($"{aircraft.Name} landed.");
                    runway.HighLightRed();

                    return;
                }
            }

            Console.WriteLine("No free runway.");
        }

        public void RequestTakeOff(Aircraft aircraft)
        {
            Console.WriteLine($"\nTakeoff request from {aircraft.Name}");

            if (!_aircraftRunways.ContainsKey(aircraft))
            {
                Console.WriteLine("Aircraft is not on runway.");
                return;
            }

            var runway = _aircraftRunways[aircraft];

            runway.IsBusy = false;

            _aircraftRunways.Remove(aircraft);

            Console.WriteLine($"{aircraft.Name} took off.");
            runway.HighLightGreen();
        }
    }

    // AIRCRAFT
    class Aircraft
    {
        public string Name { get; }

        private CommandCentre _mediator;

        public Aircraft(string name)
        {
            Name = name;
        }

        public void SetMediator(CommandCentre mediator)
        {
            _mediator = mediator;
        }

        public void RequestLanding()
        {
            _mediator.RequestLanding(this);
        }

        public void RequestTakeOff()
        {
            _mediator.RequestTakeOff(this);
        }
    }

    // RUNWAY
    class Runway
    {
        public Guid Id { get; } = Guid.NewGuid();

        public bool IsBusy { get; set; }

        public void HighLightRed()
        {
            Console.WriteLine($"Runway {Id} is BUSY");
        }

        public void HighLightGreen()
        {
            Console.WriteLine($"Runway {Id} is FREE");
        }
    }
}