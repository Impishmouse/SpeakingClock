﻿using Core.UI.Manager.Abstract;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core.UI.Controllers
{
    public class AutoListener : BaseViewController
    {
        private readonly Button button;
        private readonly UnityAction handler;

        public AutoListener(Button button, UnityAction handler)
        {
            this.button = button;
            this.handler = handler;
        }

        protected override void OnSubscribe()
        {
            button.onClick.AddListener(handler);
        }

        protected override void OnUnsubscribe()
        {
            button.onClick.RemoveListener(handler);
        }
    }
}
