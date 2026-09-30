using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace UI
{
    public class UIHolder : MonoBehaviour
    {
        private GeneralUI _generalUI;

        public void Initialize(IEnumerable<ViewUIBase> views)
        {
            _generalUI = new();
            foreach (var view in views.Where(view => view != null))
            {
                _generalUI.RegisterView(view);
            }
        }

        public bool TryShowUIPanel(Type type)
        {
            var panelUI = _generalUI.GetViewUI(type);
            if (panelUI == null)
            {
                Debug.LogWarning($"UI panel is not registered");
                return false;
            }

            panelUI.Show();
            return true;
        }
    }
}