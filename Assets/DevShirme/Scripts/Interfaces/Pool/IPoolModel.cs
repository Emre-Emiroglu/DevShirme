using DevShirme.Models.Pool;
using UnityEngine;

namespace DevShirme.Interfaces.Pool
{
    public interface IPoolModel
    {
        public ObjectPool[] ObjectPools { get; }
        public IPoolObject GetPoolObject(string poolName, Vector3 pos, Quaternion rot, Vector3 scale, Transform parent, bool useRotation = false, bool useScale = false, bool setParent = false);
    }
}
