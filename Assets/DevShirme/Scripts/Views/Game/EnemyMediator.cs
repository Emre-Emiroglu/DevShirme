using DevShirme.Interfaces;
using DevShirme.Views;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class EnemyMediator : Mediator
    {
        #region Injects
        [Inject] public EnemyView EnemyView { get; set; }
        [Inject] public IEnemyModel EnemyModel { get; set; }
        #endregion

        #region Core
        public override void PreRegister()
        {
        }
        public override void OnRegister()
        {
        }
        public override void OnRemove()
        {
        }
        #endregion
    }
}
