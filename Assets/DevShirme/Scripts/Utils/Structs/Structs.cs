using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Utils
{
    public static class Structs
    {
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

        public struct SpawnData
        {
            #region Fields
            private string poolName;
            private Vector3 pos;
            private Quaternion rot;
            private Vector3 scale;
            private Transform parent;
            private bool useRotation;
            private bool useScale;
            private bool setParent;
            #endregion

            #region Constructor
            public SpawnData(string poolName, Vector3 pos, Quaternion rot, Vector3 scale, Transform parent, bool useRotation, bool useScale, bool setParent)
            {
                this.poolName = poolName;
                this.pos = pos;
                this.rot = rot;
                this.scale = scale;
                this.parent = parent;
                this.useRotation = useRotation;
                this.useScale = useScale;
                this.setParent = setParent;
            }
            #endregion

            #region Getters
            public string PoolName => poolName;
            public Vector3 Pos => pos;
            public Quaternion Rot => rot;
            public Vector3 Scale => scale;
            public Transform Parent => parent;
            public bool UseRotation => useRotation;
            public bool UseScale => useScale;
            public bool SetParent => setParent;
            #endregion
        }

        public struct InputData
        {
            public Vector2 MovementInput;
            public Vector2 RotationInput;
            public Enums.MovementState MovementState;
            public bool LeftClick;
            public bool IsRunKeyPressed;
            public bool IsJumpKeyPressed;
        }

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

        [Serializable]
        public struct MobileInputData
        {
            [SerializeField] private Enums.MobileInputBehavior mobileInputBehavior;
            [SerializeField] private bool lerp;
            [SerializeField] private float lerpSpeed;
            [SerializeField] private float sensitivity;
            [SerializeField] private float clampDistance;
            [SerializeField] private bool swipe;

            #region Getters
            public Enums.MobileInputBehavior MobileInputBehavior => mobileInputBehavior;
            public bool Lerp => lerp;
            public float LerpSpeed => lerpSpeed;
            public float Sensitivity => sensitivity;
            public float ClampDistance => clampDistance;
            public bool Swipe => swipe;
            #endregion
        }

        [Serializable]
        public struct PCInputData
        {
            [SerializeField] private Enums.PCInputBehavior pcInputBehavior;
            [SerializeField] private string verticalAxis;
            [SerializeField] private string horizontalAxis;
            [SerializeField] private KeyCode runKey;
            [SerializeField] private KeyCode jumpKey;

            #region Getters
            public Enums.PCInputBehavior PCInputBehavior => pcInputBehavior;
            public string VerticalAxis => verticalAxis;
            public string HorizontalAxis => horizontalAxis;
            public KeyCode RunKey => runKey;
            public KeyCode JumpKey => jumpKey;
            #endregion
        }

        [Serializable]
        public struct MovementData
        {
            [SerializeField] private Enums.MovementType movementType;
            [SerializeField] private float walkSpeed;
            [SerializeField] private float runSpeed;
            [SerializeField] private float jumpPower;
            [SerializeField] private ForceMode jumpForceMode;

            #region Getters
            public Enums.MovementType MovementType => movementType;
            public float WalkSpeed => walkSpeed;
            public float RunSpeed => runSpeed;
            public float JumpPower => jumpPower;
            public ForceMode JumpForceMode => jumpForceMode;
            #endregion
        }

        [Serializable]
        public struct RotationData
        {
            [SerializeField] private float rotationSpeed;

            #region Getters
            public float RotationSpeed => rotationSpeed;
            #endregion
        }

    }
}
