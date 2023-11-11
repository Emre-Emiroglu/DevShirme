using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces.Pool
{
    public interface IEnemyModel
    {
        public float FollowSpeed { get; }
        public float TurnSpeed { get; }
    }
}

