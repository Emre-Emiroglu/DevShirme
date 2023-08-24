using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class DataSet<T>
    {
        #region Fields
        protected readonly string fileName;
        protected readonly string path;
        #endregion

        #region Constructor
        public DataSet(string fileName)
        {
            this.fileName = fileName;
            this.path = Application.persistentDataPath + "/" + this.fileName;
        }
        #endregion

        #region Executes
        public abstract void Save();
        public abstract void Load();
        #endregion
    }
}
