using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IInputModel
    {
        public Structs.PCInputData PCInputData { get; }
        public Structs.MobileInputData MobileInputData { get; }
    }
}

