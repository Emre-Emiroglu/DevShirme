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
    public class DataContext : MVCSContext
    {
        #region Fields
        private DataSignal dataSignal;
        #endregion

        #region Core
        public DataContext(MonoBehaviour view) : base(view)
        {
        }
        public DataContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
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

            dataSignal = new DataSignal();

            injectionBinds();
            mediationBinds();
            commandBinds();
        }
        public override void Launch()
        {
            dataSignal.OnInitializeData?.Dispatch();
        }
        #endregion

        #region Bindings
        private void injectionBinds()
        {
            injectionBinder.Bind<DataSignal>().To(dataSignal).ToSingleton().CrossContext();

            injectionBinder.Bind<IDataModel>().To<DataModel>().ToSingleton().CrossContext();
        }
        private void mediationBinds()
        {
        }
        private void commandBinds()
        {
            commandBinder.Bind(dataSignal.OnInitializeData).To<InitializeDataCommand>().Once();
        }
        #endregion
    }
}
