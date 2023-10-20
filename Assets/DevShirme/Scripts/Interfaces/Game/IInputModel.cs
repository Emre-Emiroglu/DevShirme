using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Interfaces
{
    public interface IInputModel: IInitializable
    {
        public Structs.PCInputData PCInputData { get; }
        public Structs.MobileInputData MobileInputData { get; }
    }
}

