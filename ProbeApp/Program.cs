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
            probe.temperatureChanged += DisplayYellow;
            probe.temperatureChanged += DisplayGreen;

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