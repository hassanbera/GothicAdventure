public interface IExperienceSubject
{
    void RegisterObserver(IExperienceObserver observer);
    void RemoveObserver(IExperienceObserver observer);
    void NotifyObservers();
}
