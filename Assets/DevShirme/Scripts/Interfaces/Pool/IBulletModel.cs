using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Interfaces
{
    public interface IBulletModel: IInitializable
    {
        public float Speed { get; }
    }
}
