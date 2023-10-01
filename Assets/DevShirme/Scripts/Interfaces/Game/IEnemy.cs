using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IEnemy
    {
        public Action<IEnemy> OnDead { get; set; }
        public void Dead();
        public void Follow(Transform target, float followSpeed, float turnSpeed);
    }
}
