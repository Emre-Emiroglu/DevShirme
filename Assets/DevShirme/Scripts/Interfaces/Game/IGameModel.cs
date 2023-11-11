using DevShirme.Utils.Enums;
using UnityEngine;

namespace DevShirme.Interfaces.Game
{
    public interface IGameModel
    {
        public Enums.GameState GameState { get; set; }
        public int TargetFPS { get; }
        public bool IsCursorActive { get; }
        public CursorLockMode CursorLockMode { get; }
    }
}

