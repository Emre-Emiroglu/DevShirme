using DevShirme.Models.Data;
using UnityEngine;
using Zenject;

namespace DevShirme.Datas.Settings.Data
{
    [CreateAssetMenu(fileName = "DataSettings", menuName = "DevShirme/Datas/Settings/DataSettings", order = 0)]
    public class DataSettings : ScriptableObjectInstaller<DataSettings>
    {
        #region Fields
        [Header("Data Models")]
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
