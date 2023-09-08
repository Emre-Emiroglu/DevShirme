using DevShirme.Modules.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IPlayerAgent: IAgentHandler
    {
        public void Initialize(ISubject subject, CharacterControllerSettings playerSettings);
    }
}
