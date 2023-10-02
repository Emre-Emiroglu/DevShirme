using DevShirme.Settings;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IPlayerModel: IInitializable
    {
        public PlayerSettings PlayerSettings { get; }
    }
}

