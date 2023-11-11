using DevShirme.Utils.Structs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Interfaces.Game
{
    public interface IPlayerModel: IInitializable
    {
        public Structs.MovementData MovementData { get; }
        public Structs.RotationData RotationData { get; }
        public Transform PlayerTransform { get; }
    }
}

