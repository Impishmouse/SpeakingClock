namespace Core.UI.Manager.Abstract
{
    public interface IViewController
    {
        void Subscribe();
        void Unsubscribe();
        void Update();
    }
}
