using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.PoolModule
{
    public class PoolParticles : PoolObject
    {
        #region Fields
        private ParticleSystem particle;
        private bool loopParticle;
        private float completeTime;
        private float destroyTime;
        #endregion

        #region Particle Core
        public override void initilaze()
        {
            base.initilaze();
            particle = GetComponent<ParticleSystem>();
            loopParticle = particle.main.loop;
            completeTime = particle.main.duration;
        }
        public override void SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
        {
            base.SpawnObj(pos, useRotation, rot, useScale, scale, setParent, p);
            obj.SetActive(true);
            destroyTime = Time.time + completeTime;
        }
        void Update()
        {
            if (!loopParticle && InUse)
            {
                if (Time.time >= destroyTime)
                {
                    DespawnObj();
                }
            }
        }
        #endregion
    }
}
