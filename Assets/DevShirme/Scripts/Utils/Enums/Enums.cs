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
        [Flags]
        public enum ManagerType : int
        {
            DataManager = 1,
            PoolManager = 2,
            GameManager = 4,
        }
        [Flags]
        public enum ModuleType: int
        {
            ADModule = 1,
            PlayerModule = 2,
            CameraModule = 4,
            UIModule = 8,
        }
        [Flags]
        public enum PlayerModuleControllerType : int
        {
            InputController = 1,
            CharacterController = 2,
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
        public enum ADType : int
        {
            Banner = 0,
            Interstital = 1,
            Rewarded = 2
        }
        public enum UIPanelType : int
        {
            MainMenuPanel = 0,
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
        public enum NotificationType: int
        {
            A = 0,
            B = 1
        }
        public enum SubjectType : int
        {
            Action = 0,
            NotAction = 1
        }
    }
}
