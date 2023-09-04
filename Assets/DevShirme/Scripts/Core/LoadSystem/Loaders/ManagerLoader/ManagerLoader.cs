using DevShirme.Managers.DataManager;
using DevShirme.Managers.GameManager;
using DevShirme.Managers.PoolManager;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class ManagerLoader : Loader
    {
        #region Fields
        private readonly Enums.ManagerType managerType;
        #endregion

        #region Core
        public ManagerLoader(Enums.ManagerType managerType, ScriptableObject[] scriptableObjects) : base(scriptableObjects)
        {
            this.managerType = managerType;
        }
        public override void Load()
        {
            bool hasDM = managerType.HasFlag(Enums.ManagerType.DataManager);
            bool hasPM = managerType.HasFlag(Enums.ManagerType.PoolManager);
            bool hasGM = managerType.HasFlag(Enums.ManagerType.GameManager);

            if (hasDM)
                create(Enums.ManagerType.DataManager);
            if (hasPM)
                create(Enums.ManagerType.PoolManager);
            if (hasGM)
                create(Enums.ManagerType.GameManager);
        }
        private void create(Enums.ManagerType managerType)
        {
            int indexValue = Utilities.FlagsValueToIndex(((int)managerType));
            ScriptableObject settings = _scriptableObjects[indexValue];
            if (!isContain(indexValue))
            {
                Manager manager = null;
                switch (managerType)
                {
                    case Enums.ManagerType.DataManager:
                        manager = new DataManager(settings);
                        break;
                    case Enums.ManagerType.PoolManager:
                        manager = new PoolManager(settings);
                        break;
                    case Enums.ManagerType.GameManager:
                        manager = new GameManager(settings);
                        break;
                }
                _loadables.Add(indexValue, manager);
                _loadeds.Add(manager);
            }
        }
        #endregion
    }
}
