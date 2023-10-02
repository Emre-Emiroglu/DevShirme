using DevShirme.Models;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IPoolModel: IInitializable
    {
        public PoolSettings PoolSettings { get; }
        public ObjectPool[] ObjectPools { get; }
    }
}
