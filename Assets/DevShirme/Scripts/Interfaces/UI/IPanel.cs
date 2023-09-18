using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IPanel: IInitializeable
    {
        public Enums.UIPanelType PanelType { get; }
        public void Show();
        public void Hide();
    }
}
