namespace AGNBack.Interfaces
{
    public interface IChronometer
    {
        string Value { get; }

        void Start();

        void Pause();

        void Stop();

        void IncrementElapsedTime();
    }
}
