namespace DD_Character.Utilitaire.Eventless
{
    public interface IBindsTo<in T>
    {
        void Bind(T context);
    }
}