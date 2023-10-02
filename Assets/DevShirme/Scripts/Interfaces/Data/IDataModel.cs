using DevShirme.Settings;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IDataModel: IInitializable
    {
        public DataSettings DataSettings { get; }
        public Structs.PlayerData PlayerData { get; set; }
        public void Save();
        public void Load();
    }
}
