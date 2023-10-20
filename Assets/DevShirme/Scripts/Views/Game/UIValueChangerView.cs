using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views
{
    public class UIValueChangerView : MonoBehaviour
    {
        #region Fields
        [Header("UI Value Changer Components")]
        [SerializeField] private float valueChangeDuration = .25f;
        private Coroutine changer;
        protected float value;
        #endregion

        #region Executes
        protected float ChangeValue(float targetValue)
        {
            if (changer != null)
            {
                StopCoroutine(changer);
            }
            changer = StartCoroutine(Change(targetValue));
            return value;
        }
        private IEnumerator Change(float targetValue)
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
