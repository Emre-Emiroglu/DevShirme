using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Interfaces
{
    public interface IEnemySpawnerModel: IInitializable
    {
        public float Duration { get; }
        public float Radius { get; }
        public bool UseGizmo { get; }
        public Color GizmoColor { get; }
    }
}
