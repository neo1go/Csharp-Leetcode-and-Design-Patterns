namespace DependencyInjectionBlazorDemo
{
    public class CounterService
    {
        public int CurrentCount { get; private set; } = 0;


        public void IncrementCount()
        {
            CurrentCount++;
        }
    }
}
