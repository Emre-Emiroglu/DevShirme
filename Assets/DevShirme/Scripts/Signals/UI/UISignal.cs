using DevShirme.Utils;
using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Signals
{
    public class UISignal
    {
        public Signal OnInitializeUI = new Signal();
        public Signal<Enums.UIPanelType> OnTransationToNewPanel = new Signal<Enums.UIPanelType>();
    }
}
