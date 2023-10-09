using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IEnemySpawnerModel
    {
        public EnemySpawnerSettings EnemySpawnerSettings { get; }
    }
}
