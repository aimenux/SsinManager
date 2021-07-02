namespace Lib.Helpers
{
    public interface IConsoleHelper
    {
        void RenderTitle(string text);

        void RenderSsins(params string[] ssins);

        void RenderSsin(string ssin, string cipherSsin);

        void RenderSsin(string ssin, bool isValid);
    }
}
