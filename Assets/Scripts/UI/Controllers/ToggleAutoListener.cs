using Core.UI.Manager.Abstract;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core.UI.Controllers
{
    public class ToggleAutoListener : BaseViewController
    {
        private readonly Toggle toggle;
        private readonly UnityAction<bool> handler;

        public ToggleAutoListener(Toggle toggle, UnityAction<bool> handler)
        {
            this.toggle = toggle;
            this.handler = handler;
        }

        protected override void OnSubscribe()
        {
            toggle.onValueChanged.AddListener(handler);
        }

        protected override void OnUnsubscribe()
        {
            toggle.onValueChanged.RemoveListener(handler);
        }
    }
}
