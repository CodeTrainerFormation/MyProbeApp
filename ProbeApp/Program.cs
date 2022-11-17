using ProbeLibrary;

namespace ProbeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lancement de l'application");

            Probe probe = new Probe();

            // abonnement des méthodes (qui respecte la définition du delegate)
            probe.TemperatureChanged += DisplayYellow;
            probe.TemperatureChanged += DisplayGreen;

            // abonnement d'une méthode anonyme (qui respecte la définition du delegate)
            probe.TemperatureChanged += delegate (int value)
            {
                if (value < 25)
                    return;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"température detectée : {value}, climatisation lancée");
                Console.ForegroundColor = ConsoleColor.White;
            };

            // abonnement d'une méthode anonyme en lambda (qui respecte la définition du delegate)
            probe.TemperatureChanged += value =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                if(value > 25)
                    Console.WriteLine($"température detectée : {value}, persiennes inclinées");
                else if(value < 22)
                    Console.WriteLine($"température detectée : {value}, persiennes ouvertes");

                Console.ForegroundColor = ConsoleColor.White;
            };

            // désabonnement d'une méthode
            // probe.TemperatureChanged -= DisplayGreen;

            // désabonnement de toutes les méthodes (si get/set)
            // probe.TemperatureChanged = null;

            // -- interdit grâce à 'event' (dans la classe Probe) --
            // probe.temperatureChanged(50);

            // lancement de la simulation
            probe.Execute();

            Console.WriteLine("Fin de l'application");
        }

        static void DisplayYellow(int value)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"température detectée - indicateur: {value}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void DisplayGreen(int value)
        {
            if (value > 17)
                return;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"température detectée : {value}, je lance le chauffage");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}