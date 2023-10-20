using DevShirme.Models;
using DevShirme.Views;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class PoolObjectMediator : MonoBehaviour, IDisposable
    {
        #region Fields
        private PoolObjectView poolObjectView;
        #endregion

        #region Core
        [Zenject.Inject]
        public void Construct(PoolObjectView poolObjectView)
        {
            this.poolObjectView = poolObjectView;

            poolObjectView.OnSpawn += onSpawn;
            poolObjectView.OnDeSpawn += onDeSpawn;
        }
        public void Dispose()
        {
            poolObjectView.OnSpawn -= onSpawn;
            poolObjectView.OnDeSpawn -= onDeSpawn;
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
