using DevShirme.Interfaces;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DesignPatterns.Behaviorals
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "DevShirme/Events/GameEvent")]
    public class GameEvent : ScriptableObject, ISubject
    {
        #region Fields
        [Header("GameEvent Settings")]
        [SerializeField] private Structs.SubjectData subjectData;
        private ISubject subject;
        #endregion

        #region Core
        public void Initialize()
        {
            switch (subjectData.SubjectType)
            {
                case Enums.SubjectType.Action:
                    subject = new ActionSubject(subjectData);
                    break;
                case Enums.SubjectType.NotAction:
                    subject = new NotActionSubject(subjectData);
                    break;
            }
        }
        public void Attach(IObserver observer) => subject.Attach(observer);
        public void DeAttach(IObserver observer) => subject.DeAttach(observer);
        public void Notify(object value, Enums.NotificationType notificationType) => subject.Notify(value, notificationType);
        #endregion
    }
}
