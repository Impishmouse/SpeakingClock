﻿using System;
using Core.UI.Controllers;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Core.UI.Manager.Abstract
{
    public class BaseView : MonoBehaviour
    {
        public event Action<BaseView> OnActiveChange;
        public event Action<BaseView> OnShowEndEvent;

		public event Action<BaseView> OnHideBeginEvent;
        public event Action<BaseView> OnHideEndEvent;

#pragma warning disable 0649
		public Image imageBackground;
#pragma warning restore 0649

        private ViewProcessor processor = new ViewProcessor();
        private bool active = true;
        private Canvas canvas;

        private bool buttonsEnabled;
        private bool isDestroyed = false;

        protected bool destroyOnHide = true;

		public bool HaveBackgroudImage { get; private set; }

        public void AddController(BaseViewController viewController)
        {
            processor.AddItem(viewController);
        }

        public void AddController(Button button, Action action)
        {
            AddController(new AutoListener(button, () => action()));
        }

        public void AddController(Toggle toggle, Action<bool> action)
        {
            AddController(new ToggleAutoListener(toggle, res => action(res)));
        }

        protected void AssertIsNotNullElements(params MonoBehaviour[] elements)
        {
            foreach (var element in elements)
            {
                Assert.IsNotNull(element, $"Field is not assigned in {this.GetType()}");
            }
        }

        public void ShowBegin()
        {
            gameObject.SetActive(true);
            gameObject.name = gameObject.name + UnityEngine.Random.Range(0, 100).ToString();
            DisableAllButtons();
            OnShowBegin();
        }

        public void ShowEnd()
        {
            EnableAllButtons();
            OnShowEnd();
            processor.Subscribe();
        }

        protected void DisableAllButtons()
        {
            var canvasGroup = GetComponent<CanvasGroup>();

            if (canvasGroup == null)
            {
                canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }

            canvasGroup.interactable = false;

            buttonsEnabled = false;
        }

        protected void EnableAllButtons()
        {
            var canvasGroup = GetComponent<CanvasGroup>();

            if (canvasGroup == null)
            {
                canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }

            canvasGroup.interactable = true;
            buttonsEnabled = true;
        }

        public void HideBegin()
        {
            DisableAllButtons();
            OnHideBegin();
            processor.Unsubscribe();
			
			OnHideBeginEvent?.Invoke(this);
        }

        public void HideEnd()
        {
            OnHideEnd();
            if (destroyOnHide && !isDestroyed)
            {
                Destroy(gameObject);
            }
        }

        protected virtual void Update()
        {
            processor.Update();

            if (buttonsEnabled && active && Input.GetKeyDown(KeyCode.Escape))
            {
                OnBackButton();
            }
        }

        protected virtual void Awake()
		{
			HaveBackgroudImage = imageBackground != null;
		}

        protected virtual void OnDestroy()
        {
            isDestroyed = true;
        }

        protected virtual void OnShowBegin()
        {
        }

        protected virtual void OnShowEnd()
        {
            OnShowEndEvent?.Invoke(this);
        }

        protected virtual void OnHideBegin()
        {
        }

        protected virtual void OnHideEnd()
        {
            OnHideEndEvent?.Invoke(this);
        }

        protected virtual void OnViewActive(bool active)
        {
        }

        protected virtual void OnBackButton()
        {
        }

        public bool Active
        {
            get { return active; }
            set
            {
                if (active != value)
                {
                    active = value;
                    OnViewActive(value);
                    OnActiveChange?.Invoke(this);
                }
            }
        }

        public Canvas Canvas
        {
            get { return canvas; }
			set { canvas = value; }
        }
    }
}
