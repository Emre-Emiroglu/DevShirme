using DevShirme.Utils.Structs;

namespace DevShirme.Interfaces.Game
{
    public interface IInputModel
    {
        public Structs.PCInputData PCInputData { get; }
        public Structs.MobileInputData MobileInputData { get; }
    }
}

