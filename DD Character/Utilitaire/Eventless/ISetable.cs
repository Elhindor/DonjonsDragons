namespace DD_Character.Utilitaire.Eventless
{
    public interface ISetable<T> : IGetable<T>
    {
        new T Value { get; set; }
    }
}