using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Interfaces
{
    public interface IEnemyModel: IInitializable
    {
        public float FollowSpeed { get; }
        public float TurnSpeed { get; }
    }
}

