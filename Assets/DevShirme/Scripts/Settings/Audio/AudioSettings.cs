using DevShirme.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Settings
{
    [CreateAssetMenu(fileName = "AudioSettings", menuName = "DevShirme/Settings/AudioSettings", order = 0)]
    public class AudioSettings : ScriptableObjectInstaller<AudioSettings>
    {
        #region Fields
        [SerializeField] private AudioModel audioModel;
        #endregion

        #region Bindings
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AudioModel>().FromInstance(audioModel).AsSingle();
        }
        #endregion
    }
}
