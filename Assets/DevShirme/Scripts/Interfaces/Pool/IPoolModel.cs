using DevShirme.Models;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IPoolModel
    {
        public PoolSettings PoolSettings { get; }
        public ObjectPool[] ObjectPools { get; }
        public IPoolObject GetPoolObject(string poolName, Vector3 pos, Quaternion rot, Vector3 scale, Transform parent, bool useRotation = false, bool useScale = false, bool setParent = false);
    }
}
