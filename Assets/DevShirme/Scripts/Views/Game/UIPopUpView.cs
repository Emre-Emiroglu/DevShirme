using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevShirme.Views
{
    public class UIPopUpView : MonoBehaviour
    {
        #region Fields
        [Header("PopUp Settings")]
        [SerializeField] private AnimationCurve showEase;
        [SerializeField] private AnimationCurve hideEase;
        [SerializeField] private Vector3 showScale = Vector3.one;
        [SerializeField] private Vector3 hideScale = Vector3.zero;
        [SerializeField] private float showDuration = 1f;
        [SerializeField] private float hideDuration = 1f;
        private Coroutine currentTween;
        #endregion

        #region Core
        public virtual void Show(Action callBack = null)
        {
            RefreshTween();

            StartCoroutine(Tween(showEase, showDuration, showScale));
        }
        public virtual void Hide(Action callBack = null)
        {
            RefreshTween();

            StartCoroutine(Tween(hideEase, hideDuration, hideScale));
        }
        private void RefreshTween()
        {
            if (currentTween != null)
            {
                StopCoroutine(currentTween);
            }
        }
        private IEnumerator Tween(AnimationCurve curve, float duration, Vector3 targetScale, Action callBack = null)
        {
            Vector3 oldScale = transform.localScale;
            float t = 0f;
            while (t < duration)
            {
                t += Time.deltaTime;
                transform.localScale = Vector3.Lerp(oldScale, targetScale, curve.Evaluate(t / duration));

                yield return null;
            }
            transform.localScale = targetScale;
            callBack?.Invoke();
        }
        #endregion
    }
}