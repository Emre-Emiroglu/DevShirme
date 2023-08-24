namespace DevShirme.Utils
{
    public static class Enums
    {
        public enum DestroyType
        {
            DestroyNewObj,
            DestroyOldObj
        }
        public enum ManagerType : int
        {
            DataManager = 0,
            PoolManager = 1,
            GameManager = 2,
            COUNT = 3
        }
        public enum ADType : int
        {
            Banner = 0,
            Interstital = 1,
            Rewarded = 2
        }
        public enum UIPanelType : int
        {
            MainMenuPanel = 0,
            InGamePanel = 1,
            EndGamePanel = 2
        }
        public enum MovementType
        {
            Transform,
            Rigidbody,
        }
        public enum GameOverButtonType: int
        {
            Reload = 0,
            Restart = 1,
        }
        public enum InputBehavior
        {
            Unclamped,
            Clamped
        }
        public enum CamType : int
        {
            IdleCam = 0,
            InGameCam = 1
        }
        public enum TriggerBehavior : int
        {
            OnTriggerEnter = 1,
            OnTriggerExit = 2,
            Both = 3
        }
        public enum CountDownFormatting
        {
            DaysHoursMinutesSeconds,
            HoursMinutesSeconds,
            MinutesSeconds,
            Seconds
        }
        public enum GameItemType: int
        {
            Collectable = 0,
            Obstacle = 1
        }
        public enum CollectableType : int
        {
            Coin = 0
        }
        public enum ObstacleType : int
        {
            Block = 0
        }
    }
}
