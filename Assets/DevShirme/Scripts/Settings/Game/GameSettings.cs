using DevShirme.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "DevShirme/Settings/GameSettings", order = 0)]
    public class GameSettings : ScriptableObjectInstaller<GameSettings>
    {
        #region Fields
        [Header("Game Settings")]
        [SerializeField] private GameModel gameModel;
        [SerializeField] private InputModel inputModel;
        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private WeaponModel weaponModel;
        [SerializeField] private EnemySpawnerModel enemySpawnerModel;
        [SerializeField] private UIModel uiModel;
        [SerializeField] private CameraModel cameraModel;
        [SerializeField] private ADModel adModel;
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
            Container.BindInterfacesAndSelfTo<ADModel>().FromInstance(adModel).AsSingle();
        }
        #endregion
    }
}
