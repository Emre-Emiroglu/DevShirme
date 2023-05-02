using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class Core : MonoSingleton<Core>
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private List<Manager> managers;
        [SerializeField] private ActionContainer actionContainer;
        #endregion

        #region Getters
        public Manager GetAManager(Utils.Enums.ManagerType type)
        {
            return managers[((int)type)];
        }
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();
            for (int i = 0; i < managers.Count; i++)
            {
                managers[i].Initialize();
            }
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        private void Awake()
        {
            actionContainer.Initialize();
            Initialize();
        }
        #endregion
    }
}
