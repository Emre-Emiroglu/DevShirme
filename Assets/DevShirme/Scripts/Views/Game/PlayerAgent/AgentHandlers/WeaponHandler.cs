using DevShirme.Interfaces.Game;
using DevShirme.Utils.Structs;
using UnityEngine;
using Zenject;

namespace DevShirme.Views.PlayerAgent.AgentHandlers
{
    public class WeaponHandler
    {
        #region Fields
        private readonly IWeaponModel weaponModel;
        private readonly SignalBus signalBus;
        private float timer;
        #endregion

        #region Props
        public Structs.InputData InputData { get; set; }
        #endregion

        #region Core
        public WeaponHandler(IWeaponModel weaponModel, SignalBus signalBus)
        {
            this.weaponModel = weaponModel;
            this.signalBus = signalBus;
        }
        #endregion

        #region Executes
        public void Reload()
        {
            timer = 0f;
        }
        private void ShootingTimer()
        {
            timer += Time.deltaTime;
            if (timer > weaponModel.FireRate)
            {
                timer = 0f;

                signalBus.Fire(new Structs.OnWeaponCanShoot { });
            }
        }
        #endregion

        #region GameUpdates
        public void GameUpdate()
        {
            if (!InputData.LeftClick)
                return;

            ShootingTimer();
        }
        #endregion
    }
}
