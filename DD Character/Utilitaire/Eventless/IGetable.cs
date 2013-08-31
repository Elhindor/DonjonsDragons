using System;

namespace DD_Character.Utilitaire.Eventless
{
    public interface IGetable<out T> : IGetable
    {
        T Value { get; }
    }

    public interface IGetable
    {
        event Action Changed;
    }
}