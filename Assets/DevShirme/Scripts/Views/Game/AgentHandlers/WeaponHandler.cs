using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views
{
    public class WeaponHandler : AgentHandler
    {
        #region Actions
        public Action OnWeaponCanShoot;
        #endregion

        #region Fields
        private readonly float fireRate;
        private float timer;
        #endregion

        #region Core
        public WeaponHandler(float fireRate, Transform obj, Rigidbody rb) : base(obj, rb)
        {
            this.fireRate = fireRate;
        }
        #endregion

        #region Executes
        public override void OnGameUpdate()
        {
            if (!InputData.LeftClick)
                return;

            shootingTimer();
        }
        public override void Reload()
        {
            timer = 0f;
        }
        private void shootingTimer()
        {
            timer += Time.deltaTime;
            if (timer > fireRate)
            {
                timer = 0f;
                OnWeaponCanShoot?.Invoke();
            }
        }
        #endregion
    }
}
