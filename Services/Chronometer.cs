using AGNBack.Interfaces;
using System;
using System.Windows.Threading;

namespace Services
{
    public class Chronometer : DispatcherTimer, IChronometer
    {
        public string Value
        {
            get
            {
                return TimeSpan.FromSeconds(ContadorCronometro).ToString();
            }
        }

        private int ContadorCronometro { get; set; }
        private static EventHandler _eventHandler { get; set; }

        private Chronometer() : base(DispatcherPriority.Render)
        {
            IniciarContador();
        }

        /// <summary>
        /// Inicializa el contador a 0 o a los segundos recividos
        /// </summary>
        private void IniciarContador(int segundos = 0)
        {
            ContadorCronometro = segundos;
        }

        /// <summary>
        /// Metodo 'Factory' para crear una instancia del cronometro con la que trabajar
        /// </summary>
        /// <param name="eventHandler">El metodo al que llamarà el cronometro cada tick(1 segundo en este caso)</param>
        /// <returns>El objeto con el que trabajar</returns>
        public static Chronometer Create(EventHandler eventHandler)
        {
            var timer = new Chronometer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += _eventHandler = eventHandler;

            return timer;
        }

        /// <summary>
        /// Incrementa el contador del cronometro
        /// </summary>
        public void IncrementElapsedTime()
        {
            ContadorCronometro++;
        }

        /// <summary>
        /// Arranca el cronómetro
        /// </summary>
        public new void Start()
        {
            base.Start();
        }

        /// <summary>
        /// Pausa el cronómetro.
        /// </summary>
        public void Pause()
        {
            base.Stop();
        }

        /// <summary>
        /// Para el cronómetro y reinicia el contador del cronómetro.
        /// </summary>
        public new void Stop()
        {
            base.Stop();
            IniciarContador(-1);
            _eventHandler.Invoke(this, null);
        }
    }
}
