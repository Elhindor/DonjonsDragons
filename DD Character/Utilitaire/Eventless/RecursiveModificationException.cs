using System;

namespace DD_Character.Utilitaire.Eventless
{
    public sealed class RecursiveModificationException : Exception
    {
        public RecursiveModificationException()
            : base("Recursive modification of Setable")
        {
        }
    }
}