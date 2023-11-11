using DevShirme.Models.Game;
using UnityEngine;
using Zenject;

namespace DevShirme.Datas.Settings.Game
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "DevShirme/Datas/Settings/GameSettings", order = 0)]
    public class GameSettings : ScriptableObjectInstaller<GameSettings>
    {
        #region Fields
        [Header("Game Models")]
        [SerializeField] private GameModel gameModel;
        [SerializeField] private InputModel inputModel;
        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private WeaponModel weaponModel;
        [SerializeField] private EnemySpawnerModel enemySpawnerModel;
        [SerializeField] private UIModel uiModel;
        [SerializeField] private CameraModel cameraModel;
        #endregion

        #region Bindings
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameModel>().FromInstance(gameModel).AsSingle();
            Container.BindInterfacesAndSelfTo<InputModel>().FromInstance(inputModel).AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerModel>().FromInstance(playerModel).AsSingle();
            Container.BindInterfacesAndSelfTo<WeaponModel>().FromInstance(weaponModel).AsSingle();
            Container.BindInterfacesAndSelfTo<EnemySpawnerModel>().FromInstance(enemySpawnerModel).AsSingle();
            Container.BindInterfacesAndSelfTo<UIModel>().FromInstance(uiModel).AsSingle();
            Container.BindInterfacesAndSelfTo<CameraModel>().FromInstance(cameraModel).AsSingle();
        }
        #endregion
    }
}
