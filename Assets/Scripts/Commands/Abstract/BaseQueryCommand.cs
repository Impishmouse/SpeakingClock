using System;
using Core.UI.Manager;
using Core.UI.Manager.Transitions;
using Redactor.UI.Dialogs.Info;
using Redactor.UI.Dialogs.Loading;

namespace Redactor.Commands.Abstract
{
    public abstract class BaseQueryCommand:IQueryCommand
    {
        public abstract event Action<bool> CompleteEvent;

        public LoadingRedactorDialog LoadingDialog { get; set; }

        protected void ShowLoader()
        {
            if (LoadingDialog == null)
            {
                LoadingDialog = UIManager.OpenDialog<LoadingRedactorDialog, AnimateTransition>();
            }
        }

        protected void HideLoader()
        {
            LoadingDialog?.Close();
        }
        
        public abstract void Execute();

        protected virtual void CheckResult(RequestResultData result)
        {
            if (!result.IsSuccess)
            {
                UIManager.OpenDialog<InfoRedactorDialog, AnimateTransition>().Initialize(result.Text + "\n\n" + result.Error);
            }
        }
    }
}
