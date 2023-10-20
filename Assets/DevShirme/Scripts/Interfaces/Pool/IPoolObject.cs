using UnityEngine;
using Zenject;

namespace DevShirme.Interfaces
{
    public interface IPoolObject: IInitializable
    {
        public bool InUse { get; }
        public void Spawn(Vector3 pos, Quaternion rot, Vector3 scale, Transform parent, bool useRotation = false, bool useScale = false, bool setParent = false);
        public void DeSpawn();
    }
}
