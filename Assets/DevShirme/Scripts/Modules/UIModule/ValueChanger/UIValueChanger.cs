using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.UIModule
{
    public class UIValueChanger : MonoBehaviour
    {
        #region Fields
        [Header("UI Value Changer Components")]
        [SerializeField] private float valueChangeDuration = .25f;
        private Coroutine changer;
        protected float value;
        #endregion

        #region Core
        public virtual void Initialize() { }
        #endregion

        #region Executes
        protected float changeValue(float targetValue)
        {
            if (changer != null)
            {
                StopCoroutine(changer);
            }
            changer = StartCoroutine(change(targetValue));
            return value;
        }
        private IEnumerator change(float targetValue)
        {
            float oldValue = value;
            float t = 0f;
            while (t < valueChangeDuration)
            {
                t += Time.deltaTime;

                value = Mathf.Lerp(oldValue, targetValue, t / valueChangeDuration);

                yield return null;
            }

            value = targetValue;
        }
        #endregion
    }
}
