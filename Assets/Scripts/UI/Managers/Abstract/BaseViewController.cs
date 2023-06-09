namespace Core.UI.Manager.Abstract
{
    public class BaseViewController : IViewController
    {
        public void Subscribe()
        {
            OnSubscribe();
        }

        public void Unsubscribe()
        {
            OnUnsubscribe();
        }

        public void Update()
        {
            OnUpdate();
        }

        protected virtual void OnSubscribe()
        {

        }

        protected virtual void OnUnsubscribe()
        {

        }

        protected virtual void OnUpdate()
        {
            
        }
    }
}
