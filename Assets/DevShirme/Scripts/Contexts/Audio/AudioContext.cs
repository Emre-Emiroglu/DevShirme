using DevShirme.Controllers;
using DevShirme.Interfaces;
using DevShirme.Models;
using DevShirme.Signals;
using strange.examples.signals;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Contexts
{
    public class AudioContext : MVCSContext
    {
        #region Fields
        private AudioSignal audioSignal;
        #endregion

        #region Core
        public AudioContext(MonoBehaviour view) : base(view)
        {
        }
        public AudioContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
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

            audioSignal = new AudioSignal();

            injectionBinds();
            commandBinds();
            mediationBinds();
        }
        #endregion

        #region Bindings
        private void injectionBinds()
        {
            injectionBinder.Bind<IAudioModel>().To<AudioModel>().ToSingleton().CrossContext();
        }
        private void commandBinds()
        {
            commandBinder.Bind(audioSignal.OnPlaySound).To<PlaySoundCommand>();
        }
        private void mediationBinds()
        {
        }
        #endregion
    }
}
