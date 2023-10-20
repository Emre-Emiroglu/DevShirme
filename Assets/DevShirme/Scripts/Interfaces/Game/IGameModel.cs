using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Interfaces
{
    public interface IGameModel: IInitializable
    {
        public Enums.GameState GameState { get; set; }
        public int TargetFPS { get; }
        public bool IsCursorActive { get; }
        public CursorLockMode CursorLockMode { get; }
    }
}

