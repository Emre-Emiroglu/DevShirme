namespace DevShirme
{
    public interface IGameCycle
    {
        #region Core
        public void Initialize();
        public void GameStart();
        public void Reload();
        public void GameOver();
        public void GameSuccess();
        public void GameFail();
        #endregion
    }
}
