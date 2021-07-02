namespace Lib.Ssins
{
    public interface ISsinSelector
    {
        T Resolve<T>(string country) where T : class;
    }
}