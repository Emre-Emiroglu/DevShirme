using DevShirme.DesignPatterns.Behaviorals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.UIModule
{
    public class GameEventButton : UIButton
    {
        #region Fields
        [SerializeField] private GameEvent gameEvent;
        #endregion

        #region Core
        public override void Setup()
        {
            base.Setup();
        }
        public override void OnPressed()
        {
            gameEvent?.Notify(null);
        }
        #endregion
    }
}
