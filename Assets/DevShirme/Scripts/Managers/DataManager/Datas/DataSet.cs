using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace DevShirme
{
    public abstract class DataSet<T>
    {
        #region Fields
        protected string fileName;
        #endregion

        #region Getters
        protected string getPath(string fileName)
        {
            return Application.persistentDataPath + "/" + fileName;
        }
        #endregion

        #region Constructor
        public DataSet(string fileName)
        {
            this.fileName = fileName;
        }
        #endregion

        #region Executes
        public abstract void Save();
        public abstract void Load();
        public virtual void Clear()
        {
            if (File.Exists(getPath(fileName)))
            {
                File.Delete(getPath(fileName));
            }
        }
        #endregion
    }

}
