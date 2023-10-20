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
            Container.BindInstance(gameModel);
            Container.BindInstance(inputModel);
            Container.BindInstance(playerModel);
            Container.BindInstance(weaponModel);
            Container.BindInstance(enemySpawnerModel);
            Container.BindInstance(uiModel);
            Container.BindInstance(cameraModel);
            Container.BindInstance(adModel);
        }
        #endregion
    }
}
