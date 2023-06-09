﻿using System.Collections.Generic;
using Core.UI.Manager.Abstract;

namespace Core.UI.Manager
{
    public class ViewProcessor : IViewController
    {
        private List<IViewController> items = new List<IViewController>();

        public void AddItem(IViewController controller)
        {
            items.Add(controller);
        }

        public void Subscribe()
        {
            items.ForEach(i => i.Subscribe());
        }

        public void Unsubscribe()
        {
            items.ForEach(i => i.Unsubscribe());
        }

        public void Update()
        {
            items.ForEach(i => i.Update());
        }
    }
}
