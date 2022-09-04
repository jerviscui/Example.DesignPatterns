namespace PrototypeTest;

public interface ICloneable<T> : ICloneable where T : class
{
    /// <summary>
    /// Clones this instance.
    /// </summary>
    public new T Clone();
}
