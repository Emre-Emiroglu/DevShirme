using DevShirme.Interfaces;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public class WeaponHandler : AgentHandler
    {
        #region Fields
        private readonly IWeapon weapon;
        private readonly float fireRate;
        private float timer;
        #endregion

        #region Core
        public WeaponHandler(IWeapon weapon, Transform obj, Rigidbody rb) : base(obj, rb)
        {
            this.weapon = weapon;
            this.weapon.Setup(true);

            fireRate = this.weapon.WeaponData.FireRate;
        }
        #endregion

        #region Executes
        public override void Execute(Vector2 input, Enums.MovementState keyCodeState)
        {
            timer += Time.deltaTime;
            if (timer > fireRate)
            {
                timer = 0f;
                weapon.Shoot();
            }
        }
        #endregion
    }
}
