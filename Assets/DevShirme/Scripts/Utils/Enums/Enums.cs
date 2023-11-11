
namespace DevShirme.Utils.Enums
{
    public static class Enums
    {
        public enum MobileInputBehavior
        {
            Unclamped,
            Clamped
        }
        public enum PCInputBehavior
        {
            Raw,
            NonRaw
        }
        public enum MovementType
        {
            Transform,
            Rigidbody
        }
        public enum MovementState
        {
            Walk = 0,
            Run = 1,
        }
        public enum UIPanelType : int
        {
            MainMenuPanel = 0,
            InGamePanel = 1,
            EndGamePanel = 2
        }
        public enum UIButtonType : int
        {
            GameStart = 0,
            GameReload = 1,
        }
        public enum CamType : int
        {
            IdleCam = 0,
            FollowCam = 1
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
        public enum GameState : int
        {
            Init = 0,
            Start = 1,
            Over = 2,
            Reload = 3
        }
        public enum AudioSourceTypes: int
        {
            PlayerAudioSource = 0,
            InGameAudioSource = 1,
            MusicAudioSource = 2,
            UIAudioSource = 3,
        }
    }
}
