using DevShirme.Utils;
using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Signals
{
    public class GameSignal
    {
        public Signal<Enums.GameState> OnChangeGameState = new Signal<Enums.GameState>();
        public Signal OnGameUpdate = new Signal();

        public Signal<Enums.ADType> OnShowAD = new Signal<Enums.ADType>();

        public Signal<Enums.CamType> OnTransationToNewCam = new Signal<Enums.CamType>();
        public Signal<Enums.CamType> OnShakeCam = new Signal<Enums.CamType>();
        public Signal<Enums.CamType, float> OnChangeCamFov = new Signal<Enums.CamType, float>();
    }
}
