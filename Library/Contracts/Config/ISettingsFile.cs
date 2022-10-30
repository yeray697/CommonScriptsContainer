namespace Contracts.Config
{
    public interface ISettingsFile<T> : ICloneable, IEquatable<T>
    {
        void CopyFrom(T model);
    }
}
