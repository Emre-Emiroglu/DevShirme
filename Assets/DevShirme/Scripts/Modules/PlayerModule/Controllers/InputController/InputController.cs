﻿using DevShirme.Interfaces;
using DevShirme.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public abstract class InputController: Controller, ISubject
    {
        #region Actions
        protected Action<object, Enums.NotificationType> _onInputValueChaged;
        #endregion

        #region Fields
        protected readonly InputControllerSettings _icSettings;
        #endregion

        #region Core
        public InputController(ScriptableObject _settings) : base(_settings)
        {
            _icSettings = _settings as InputControllerSettings;
        }
        public abstract void ClearInputs();
        protected abstract void inputUpdate();
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
        }
        public override void ExternalFixedUpdate()
        {
        }
        #endregion

        #region Subject
        public void Attach(IObserver observer)
        {
            _onInputValueChaged += observer.OnNotify;
        }
        public void DeAttach(IObserver observer)
        {
            _onInputValueChaged -= observer.OnNotify;
        }
        public void Notify(object value, Enums.NotificationType notificationType)
        {
            _onInputValueChaged?.Invoke(value, notificationType);
        }
        #endregion
    }
}
