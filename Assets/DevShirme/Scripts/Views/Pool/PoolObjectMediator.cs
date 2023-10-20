using DevShirme.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Mediators
{
    public class PoolObjectMediator : MonoBehaviour, IDisposable
    {
        #region Fields
        private PoolObjectView poolObjectView;
        #endregion

        #region Core
        [Inject]
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
