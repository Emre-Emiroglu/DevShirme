using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DevShirme.Utils;

namespace DevShirme.Helpers
{
    public class PhysicListener : MonoBehaviour
    {
        #region Fields
        [Header("Physic Listener Fields")]
        public Enums.TriggerBehavior Trigger = Enums.TriggerBehavior.OnTriggerEnter;
        public string CompareTagName;
        public UnityEvent TriggerEnterCallback;
        public UnityEvent TriggerExitCallback;
        private Collider contactCol;
        #endregion

        #region Getters
        public Collider ContactCol => contactCol;
        #endregion

        #region Triggers
        private void OnTriggerEnter(Collider other)
        {
            if (Trigger == Enums.TriggerBehavior.OnTriggerEnter || Trigger == Enums.TriggerBehavior.Both)
            {
                if (other.gameObject.CompareTag(CompareTagName) || other.tag == "")
                {
                    contactCol = other;
                    TriggerEnterCallback?.Invoke();
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (Trigger == Enums.TriggerBehavior.OnTriggerExit || Trigger == Enums.TriggerBehavior.Both)
            {
                if (other.gameObject.CompareTag(CompareTagName) || other.tag == "")
                {
                    contactCol = other;
                    TriggerExitCallback?.Invoke();
                }
            }
        }
        #endregion
    }
}
