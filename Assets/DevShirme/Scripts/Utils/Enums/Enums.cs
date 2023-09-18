using System;

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
            AudioManager = 3
        }
        public enum ModuleType : int
        {
            ADModule = 0,
            PlayerModule = 1,
            CameraModule = 2,
            UIModule = 3,
            EnemyModule = 4,
        }
        public enum PlayerModuleControllerType: int
        {
            InputController = 0,
            CharacterController = 1
        }
        public enum EnemyModuleControllerType : int
        {
            SpawnController = 0,
        }
        public enum InputType
        {
            Mobile,
            PC
        }
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
            Jump = 2
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
        public enum NotificationType: int
        {
            GameStart = 0,
            GameOver = 1,
            GameReload = 2,
            WeaponShoot = 3,
        }
        public enum SubjectType : int
        {
            Action = 0,
            NotAction = 1
        }
    }
}
