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
    public class UIContext : MVCSContext
    {
        #region Fields
        private UISignal uiSignal;
        #endregion

        #region Core
        public UIContext(MonoBehaviour view) : base(view)
        {
        }
        public UIContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
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

            uiSignal = new UISignal();

            injectionBinds();
            commandBinds();
            mediationBinds();
        }
        #endregion

        #region Bindings
        private void injectionBinds()
        {
            injectionBinder.Bind<IUIModel>().To<UIModel>().ToSingleton().CrossContext();
        }
        private void commandBinds()
        {
        }
        private void mediationBinds()
        {
            mediationBinder.Bind<UIPanelView[]>().To<UIPanelMediator[]>();
        }
        #endregion
    }
}
