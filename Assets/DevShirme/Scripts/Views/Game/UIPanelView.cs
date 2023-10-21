using UnityEngine;
using System.Collections;
using DevShirme.Utils;
using Zenject;
using System;

namespace DevShirme.Views
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIPanelView : MonoBehaviour, IDisposable
    {
        #region Injects
        private SignalBus signalBus;
        #endregion

        #region Fields
        [Header("Panel Fields")]
        [SerializeField] private Enums.UIPanelType panelType;
        [SerializeField] private Structs.PanelDatas data;
        private CanvasGroup canvasGroup;
        #endregion

        #region Core
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;

            canvasGroup = GetComponent<CanvasGroup>();

            Hide();

            signalBus.Subscribe<Structs.OnChangeGameState>(x => OnChangeGameState(x.NewGameState));
        }
        public void Dispose()
        {
            signalBus.TryUnsubscribe<Structs.OnChangeGameState>(x => OnChangeGameState(x.NewGameState));
        }
        #endregion

        #region Receivers
        private void OnChangeGameState(Enums.GameState gameState)
        {
            Enums.UIPanelType panelType = Enums.UIPanelType.MainMenuPanel;

            switch (gameState)
            {
                case Enums.GameState.Init:
                    panelType = Enums.UIPanelType.MainMenuPanel;
                    break;
                case Enums.GameState.Start:
                    panelType = Enums.UIPanelType.InGamePanel;
                    break;
                case Enums.GameState.Over:
                    panelType = Enums.UIPanelType.EndGamePanel;
                    break;
                case Enums.GameState.Reload:
                    panelType = Enums.UIPanelType.MainMenuPanel;
                    break;
            }

            bool isShow = panelType == this.panelType;
            if (isShow)
                Show();
            else
                Hide();
        }
        #endregion

        #region Executes
        protected virtual void Show()
        {
            if (data.SmoothPanels)
                StartCoroutine(SetCanvasGroupAlpha(canvasGroup, 1f, data.ShowDuration));
            else
                StartCoroutine(SetCanvasGroupAlpha(canvasGroup, 1f, 0f));

            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        protected virtual void Hide()
        {
            if (data.SmoothPanels)
                StartCoroutine(SetCanvasGroupAlpha(canvasGroup, 0f, data.HideDuration));
            else
                StartCoroutine(SetCanvasGroupAlpha(canvasGroup, 0f, 0f));

            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
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
