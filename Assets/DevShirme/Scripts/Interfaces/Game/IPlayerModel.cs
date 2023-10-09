using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IPlayerModel
    {
        public PlayerSettings PlayerSettings { get; }
        public Transform PlayerTransform { get; }
    }
}

