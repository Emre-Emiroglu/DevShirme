using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using strange.extensions.mediation.impl;

namespace DevShirme.Views
{
    public class UIPopUpView : View
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
            refreshTween();

            StartCoroutine(tween(showEase, showDuration, showScale));
        }
        public virtual void Hide(Action callBack = null)
        {
            refreshTween();

            StartCoroutine(tween(hideEase, hideDuration, hideScale));
        }
        private void refreshTween()
        {
            if (currentTween != null)
            {
                StopCoroutine(currentTween);
            }
        }
        private IEnumerator tween(AnimationCurve curve, float duration, Vector3 targetScale, Action callBack = null)
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
