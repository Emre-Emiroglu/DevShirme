using DevShirme.Utils.Structs;

namespace DevShirme.Interfaces.Data
{
    public interface IDataModel
    {
        public Structs.PlayerData PlayerData { get; set; }
        public void Save();
        public void Load();
    }
}
