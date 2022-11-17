namespace ProbeLibrary
{
    public class Probe
    {
        private event ProbeHandler temperatureChanged;
        
        // une sorte de Getter/Setter pour les events - en mode ajout/suppression de méthodes
        public event ProbeHandler TemperatureChanged
        {
            add { temperatureChanged += value; }
            remove { temperatureChanged -= value; }
        }

        /// <summary>
        /// Simulation d'une sonde
        /// </summary>
        public void Execute()
        {
            Random random = new Random();

            while (true)
            {
                // valeur au hasard permettant la simulation d'une température
                int value = random.Next(-100, 100);

                Console.WriteLine(value);

                // on vérifie s'il y a des méthodes abonnées avant l'invocation
                if (temperatureChanged != null)
                {
                    // invocation du delegate (appel des méthodes abonnées)
                    temperatureChanged(value);
                }

                // pause d'une seconde
                Thread.Sleep(1000);
            }
        }
    }
}