using UnityEngine;
using System.Collections;
using DevShirme.Utils;
using strange.extensions.mediation.impl;

namespace DevShirme.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIPanelView : View
    {
        #region Fields
        [Header("Panel Fields")]
        [SerializeField] private Enums.UIPanelType panelType;
        [SerializeField] private Structs.PanelDatas data;
        private CanvasGroup canvasGroup;
        #endregion

        #region Getters
        public Enums.UIPanelType PanelType => panelType;
        #endregion

        #region Process
        public virtual void Initialize()
        {
            canvasGroup = GetComponent<CanvasGroup>();

            Hide();
        }
        public virtual void Show()
        {
            if (data.SmoothPanels)
            {
                StartCoroutine(SetCanvasGroupAlpha(canvasGroup, 1f, data.ShowDuration));
            }
            else
            {
                StartCoroutine(SetCanvasGroupAlpha(canvasGroup, 1f, 0f));
            }
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        public virtual void Hide()
        {
            if (data.SmoothPanels)
            {
                StartCoroutine(SetCanvasGroupAlpha(canvasGroup, 0f, data.HideDuration));
            }
            else
            {
                StartCoroutine(SetCanvasGroupAlpha(canvasGroup, 0f, 0f));
            }
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        #endregion

        #region Executes
        private IEnumerator SetCanvasGroupAlpha(CanvasGroup canvasGroup, float targetValue, float duration)
        {
            float t = 0f;
            float c = canvasGroup.alpha;
            while (t < duration)
            {
                t += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(c, targetValue, t / duration);
                yield return null;
            }
            canvasGroup.alpha = targetValue;
        }
        #endregion
    }
}
