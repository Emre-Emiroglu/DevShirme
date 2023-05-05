namespace DevShirme.Interfaces
{
    public interface IModule
    {
        public void Initialize();
        public void OnGameStart();
        public void OnGameReload();
        public void OnGameOver();
        public void OnGameSuccess();
        public void OnGameFailed();
    }
}
