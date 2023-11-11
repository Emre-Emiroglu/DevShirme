using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces.Game
{
    public interface IEnemySpawnerModel
    {
        public float Duration { get; }
        public float Radius { get; }
        public bool UseGizmo { get; }
        public Color GizmoColor { get; }
    }
}
