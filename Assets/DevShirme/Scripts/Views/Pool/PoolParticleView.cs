using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views
{
    public class PoolParticleView : PoolObjectView
    {
        #region Fields
        private ParticleSystem particle;
        private bool loopParticle;
        private float completeTime;
        private float destroyTime;
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();

            particle = GetComponent<ParticleSystem>();
            loopParticle = particle.main.loop;
            completeTime = particle.main.duration;
        }
        public override void Spawn(Vector3 pos, Quaternion rot, Vector3 scale, Transform parent, bool useRotation = false, bool useScale = false, bool setParent = false)
        {
            base.Spawn(pos, rot, scale, parent, useRotation, useScale, setParent);

            obj.SetActive(true);
            destroyTime = Time.time + completeTime;
        }
        public override void DeSpawn()
        {
            base.DeSpawn();
        }
        #endregion

        #region Timer
        void Update()
        {
            if (!loopParticle && InUse)
            {
                if (Time.time >= destroyTime)
                    DeSpawn();
            }
        }
        #endregion
    }
}
