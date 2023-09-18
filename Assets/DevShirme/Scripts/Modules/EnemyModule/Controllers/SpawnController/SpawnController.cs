using DevShirme.Interfaces;
using DevShirme.Managers.PoolManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.EnemyModule
{
    public class SpawnController : Controller
    {
        #region Fields
        public Action<IPoolObject> OnSpawn;
        private readonly SpawnControllerSettings scSettings;
        private readonly Transform referanceTransform;
        private float t;
        #endregion

        #region Core
        public SpawnController(SpawnControllerSettings scSettings, Transform referanceTransform) : base()
        {
            this.scSettings = scSettings;
            this.referanceTransform = referanceTransform;

            t = 0f;
        }
        #endregion

        #region Updates
        public override void Tick()
        {
            timer();
        }
        public override void FixedTick()
        {
        }
        public override void LateTick()
        {
        }
        #endregion

        #region Spawn
        private void timer()
        {
            t += Time.deltaTime;
            if (t > scSettings.SpawnDuration)
            {
                t = 0f;

                spawn();
            }
        }
        private void spawn()
        {
            PoolManager pm = Core.Instance.GetManager(Utils.Enums.ManagerType.PoolManager) as PoolManager;

            Vector3 pos = referanceTransform.position + UnityEngine.Random.insideUnitSphere * scSettings.Radius;
            pos.y = 0f;

            IPoolObject poolObject = pm.GetObj(scSettings.PoolName, pos, Quaternion.identity, Vector3.one, null, true);

            OnSpawn?.Invoke(poolObject);
        }
        #endregion
    }
}
