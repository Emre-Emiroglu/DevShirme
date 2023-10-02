using DevShirme.Controllers;
using DevShirme.Interfaces;
using DevShirme.Mediators;
using DevShirme.Models;
using DevShirme.Signals;
using DevShirme.Views;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Contexts
{
    public class GameContext : MVCSContext
    {
        #region Fields
        private GameSignal gameSignal;
        #endregion

        #region Core
        public GameContext(MonoBehaviour view) : base(view)
        {
        }
        public GameContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
        }
        protected override void addCoreComponents()
        {
            base.addCoreComponents();

            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }
        protected override void mapBindings()
        {
            base.mapBindings();

            gameSignal = new GameSignal();

            injectionBinds();
            commandBinds();
            mediationBinds();
        }
        public override void Launch()
        {
            gameSignal.OnChangeGameState?.Dispatch(Utils.Enums.GameState.Init);
        }
        #endregion

        #region Bindings
        private void injectionBinds()
        {
            injectionBinder.Bind<GameSignal>().To(gameSignal).ToSingleton().CrossContext();

            injectionBinder.Bind<IADModel>().To<ADModel>().ToSingleton().CrossContext();
            injectionBinder.Bind<IPlayerModel>().To<PlayerModel>().ToSingleton().CrossContext();
            injectionBinder.Bind<ICameraModel>().To<CameraModel>().ToSingleton().CrossContext();
            injectionBinder.Bind<IEnemyModel>().To<EnemyModel>().ToSingleton().CrossContext();
            injectionBinder.Bind<IInputModel>().To<InputModel>().ToSingleton().CrossContext();
            injectionBinder.Bind<IGameModel>().To<GameModel>().ToSingleton().CrossContext();
            injectionBinder.Bind<IWeaponModel>().To<WeaponModel>().ToSingleton().CrossContext();
        }
        private void commandBinds()
        {
            commandBinder.Bind(gameSignal.OnChangeGameState).To<ChangeGameStateCommand>();
            commandBinder.Bind(gameSignal.OnShowAD).To<ShowADCommand>();
        }
        private void mediationBinds()
        {
            mediationBinder.Bind<PlayerAgentView>().To<PlayerAgentMediator>();
            mediationBinder.Bind<WeaponView>().To<WeaponMediator>();
            mediationBinder.Bind<CamView[]>().To<CamMediator[]>();
        }
        #endregion


    }
}
