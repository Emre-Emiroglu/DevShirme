using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Interfaces
{
    public interface IDataModel: IInitializable
    {
        public Structs.PlayerData PlayerData { get; set; }
        public void Save();
        public void Load();
    }
}
