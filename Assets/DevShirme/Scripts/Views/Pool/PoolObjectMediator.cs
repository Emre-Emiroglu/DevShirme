using DevShirme.Views;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class PoolObjectMediator : Mediator
    {
        #region Injects
        [Inject] public PoolObjectView PoolObjectView { get; set; }
        #endregion

        #region Core
        public override void PreRegister()
        {
        }
        public override void OnRegister()
        {
            PoolObjectView.OnSpawn += onSpawn;
            PoolObjectView.OnDeSpawn += onDeSpawn;
        }
        public override void OnRemove()
        {
            PoolObjectView.OnSpawn -= onSpawn;
            PoolObjectView.OnDeSpawn -= onDeSpawn;
        }
        #endregion

        #region Receivers
        private void onSpawn()
        {
        }
        private void onDeSpawn()
        {
        }
        #endregion
    }
}
