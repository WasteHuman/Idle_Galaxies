using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class GeneralUI
    {
        private readonly Dictionary<Type, IViewUI> _views = new();

        public void RegisterView(IViewUI view)
        {
            var type = view.GetType();

            if (!_views.ContainsKey(type))
            {
                _views[type] = view;
            }
            else
            {
                Debug.Log($"View {type.Name} is already registered");
            }
        }

        public IViewUI GetViewUI(Type type)
        {
            if (_views.TryGetValue(type, out var view))
            {
                return view;
            }
            Debug.LogWarning($"View {type.Name} not found in dictionary.");
            return null;
        }

        public void ShowUI(IViewUI view)
        {
            GetViewUI(view.GetType())?.Show();
        }

        public void HideUI(IViewUI view)
        {
            GetViewUI(view.GetType())?.Hide();
        }
    }
}