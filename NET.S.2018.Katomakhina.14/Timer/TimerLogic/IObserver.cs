namespace TimerLogic
{
    public interface IObserver
    {
        void Update(int seconds, object information);
        void Unregister();
    }
}
