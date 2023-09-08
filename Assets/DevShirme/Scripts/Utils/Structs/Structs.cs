using DevShirme.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Utils
{
    public static class Structs
    {
        [Serializable]
        public struct PanelDatas
        {
            [SerializeField] private bool smoothPanels;
            [SerializeField] private float showDuration;
            [SerializeField] private float hideDuration;

            #region Getters
            public bool SmoothPanels => smoothPanels;
            public float ShowDuration => showDuration;
            public float HideDuration => hideDuration;
            #endregion
        }

        public struct PlayerData
        {
            public int Level;
            public int Coin;
            public bool IsSettingsOpen;
            public bool SoundOn;
            public bool VibrateOn;
            public PlayerData(int level, int coin, bool isSettingsOpen, bool soundOn, bool vibrateOn)
            {
                Level = level;
                Coin = coin;
                IsSettingsOpen = isSettingsOpen;
                SoundOn = soundOn;
                VibrateOn = vibrateOn;
            }
        }

        [Serializable]
        public struct SubjectData
        {
            [SerializeField] private Enums.SubjectType subjectType;
            [SerializeField] private Enums.NotificationType notificationType;
            private HashSet<IObserver> observers;
            private Action<object, Enums.NotificationType> action;

            public Enums.SubjectType SubjectType => subjectType;
            public Enums.NotificationType NotificationType => notificationType;
            public HashSet<IObserver> Observers { get { return observers; } set { observers = value; } }
            public Action<object, Enums.NotificationType> Action { get { return action; } set { action = value; } }

            public SubjectData(Enums.SubjectType subjectType, Enums.NotificationType notificationType, HashSet<IObserver> observers, Action<object, Enums.NotificationType> action)
            {
                this.subjectType = subjectType;
                this.notificationType = notificationType;
                this.observers = observers;
                this.action = action;
            }
        }

        [Serializable]
        public struct MobileInputData
        {
            public Enums.MobileInputBehavior MobileInputBehavior;
            public bool Lerp;
            public float LerpSpeed;
            public float Sensitivity;
            public float ClampDistance;
            public bool Swipe;
        }

        [Serializable]
        public struct PCInputData
        {
            public Enums.PCInputBehavior PCInputBehavior;
            public string VerticalAxis;
            public string HorizontalAxis;
            public string MouseX;
            public string MouseY;
            public KeyCode RunKey;
            public KeyCode JumpKey;
        }

        [Serializable]
        public struct MovementData
        {
            public Enums.MovementType MovementType;
            public float WalkSpeed;
            public float RunSpeed;
            public float JumpPower;
            public ForceMode JumpForceMode;
        }

        [Serializable]
        public struct RotationData
        {
            public float RotationSpeed;
        }
    }
}
