public interface IHealthSubject
{
    void RegisterObserver(IHealthObserver observer);
    void RemoveObserver(IHealthObserver observer);
    void NotifyObservers();
}
