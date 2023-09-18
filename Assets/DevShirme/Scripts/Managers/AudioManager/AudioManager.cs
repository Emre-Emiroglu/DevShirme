using DevShirme.DesignPatterns.Behaviorals;
using DevShirme.Interfaces;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Managers.AudioManager
{
    public class AudioManager : Manager, IObserver
    {
        #region Fields
        private readonly AudioManagerSettings amSettings;
        private readonly AudioSource audioSource;
        private readonly GameEvent onWeaponShoot;
        #endregion

        #region Core
        public AudioManager(AudioManagerSettings amSettings, AudioSource audioSource, GameEvent onWeaponShoot) : base()
        {
            this.amSettings = amSettings;
            this.audioSource = audioSource;
            this.onWeaponShoot = onWeaponShoot;

            onWeaponShoot.Attach(this);
        }
        #endregion

        #region Observer
        public void OnNotify(object value, Enums.NotificationType notificationType)
        {
            switch (notificationType)
            {
                case Enums.NotificationType.GameStart:
                    onWeaponShoot.Attach(this);
                    break;
                case Enums.NotificationType.GameOver:
                    onWeaponShoot.DeAttach(this);
                    break;
                case Enums.NotificationType.WeaponShoot:
                    playSound((AudioClip)value);
                    break;
            }
        }
        #endregion

        #region PlaySound
        private void playSound(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
        #endregion

        #region Updates
        public override void Tick()
        {
        }
        public override void FixedTick()
        {
        }
        public override void LateTick()
        {
        }
        #endregion
    }
}
