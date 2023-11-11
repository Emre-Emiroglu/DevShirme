using DevShirme.Models.Audio;
using UnityEngine;
using Zenject;

namespace DevShirme.Datas.Settings.Audio
{
    [CreateAssetMenu(fileName = "AudioSettings", menuName = "DevShirme/Datas/Settings/AudioSettings", order = 0)]
    public class AudioSettings : ScriptableObjectInstaller<AudioSettings>
    {
        #region Fields
        [Header("Audio Models")]
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
