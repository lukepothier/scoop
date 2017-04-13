namespace Scoop
{
    public interface IScoopOverlay
    {
        void ShowOverlay();

        ScoopConfiguration Configuration { get; set; }
    }
}
