using System;
using Web;

namespace Redactor.Commands.Abstract
{
    public abstract class BaseQueryCommand:IQueryCommand
    {
        public abstract event Action<bool> CompleteEvent;

        //public LoadingRedactorDialog LoadingDialog { get; set; }

        protected void ShowLoader()
        {
            // TODO uncomment if it needs
            /*if (LoadingDialog == null)
            {
                LoadingDialog = UIManager.OpenDialog<LoadingRedactorDialog, AnimateTransition>();
            }*/
        }

        protected void HideLoader()
        {
            // TODO uncomment if it needs
            //LoadingDialog?.Close();
        }
        
        public abstract void Execute();

        protected virtual void CheckResult(RequestResultData result)
        {
            if (!result.IsSuccess)
            {
                // TODO uncomment if it needs
                //UIManager.OpenDialog<InfoRedactorDialog, AnimateTransition>().Initialize(result.Text + "\n\n" + result.Error);
            }
        }
    }
}
