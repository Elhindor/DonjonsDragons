using System;

namespace DD_Character.Utilitaire.Eventless
{
    public interface IEquate<T>
    {
        Func<T, T, bool> EqualityComparer { get; set; }
    }
}