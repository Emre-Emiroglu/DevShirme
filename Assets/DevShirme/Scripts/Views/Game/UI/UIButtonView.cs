using DevShirme.Utils.Enums;
using DevShirme.Utils.Structs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DevShirme.Views.UI
{
    [RequireComponent(typeof(Button))]
    public class UIButtonView : MonoBehaviour, IDisposable
    {
        #region Injects
        private SignalBus signalBus;
        #endregion

        #region Fields
        [Header("UI Button Settings")]
        [SerializeField] protected Enums.UIButtonType uiButtonType;
        protected Button _button;
        #endregion

        #region Core
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;

            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnPressed);
        }
        public void Dispose()
        {
            _button.onClick.RemoveListener(OnPressed);
        }
        protected virtual void OnPressed()
        {
            Structs.OnChangeGameState onChangeGameState = new Structs.OnChangeGameState();

            switch (uiButtonType)
            {
                case Enums.UIButtonType.GameStart:
                    onChangeGameState.NewGameState = Enums.GameState.Start;
                    break;
                case Enums.UIButtonType.GameReload:
                    onChangeGameState.NewGameState = Enums.GameState.Reload;
                    break;
            }

            signalBus.Fire(onChangeGameState);
        }
        #endregion
    }
}
