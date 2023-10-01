using DevShirme.Controllers;
using DevShirme.Interfaces;
using DevShirme.Models;
using DevShirme.Signals;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Contexts
{
    public class PoolContext : MVCSContext
    {
        #region Fields
        private PoolSignal poolSignal;
        #endregion

        #region Core
        public PoolContext(MonoBehaviour view) : base(view)
        {
        }
        public PoolContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
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

            poolSignal = new PoolSignal();

            injectionBinds();
            commandBinds();
            mediationBinds();
        }
        public override void Launch()
        {
        }
        #endregion

        #region Bindings
        private void injectionBinds()
        {
            injectionBinder.Bind<IPoolModel>().To<PoolModel>().ToSingleton().CrossContext();
        }
        private void commandBinds()
        {
            commandBinder.Bind(poolSignal.OnSpawn).To<SpawnCommand>();
            commandBinder.Bind(poolSignal.OnClearPool).To<ClearPoolCommand>();
        }
        private void mediationBinds()
        {
        }
        #endregion
    }
}
