using DevShirme.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Settings
{
    [CreateAssetMenu(fileName = "DataSettings", menuName = "DevShirme/Settings/DataSettings", order = 0)]
    public class DataSettings : ScriptableObjectInstaller<DataSettings>
    {
        #region Fields
        [SerializeField] private DataModel dataModel;
        #endregion

        #region Bindings
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DataModel>().FromInstance(dataModel).AsSingle();
        }
        #endregion
    }
}
