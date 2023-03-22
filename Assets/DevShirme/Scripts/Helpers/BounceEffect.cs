using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Helpers
{
    public class BounceEffect: MonoBehaviour
    {
        #region Fields
        [Header("Bounce Settings")]
        [SerializeField] private float bounceTargetScale = 1.25f;
        [SerializeField] private float bounceDelay = .1f;
        [SerializeField] private float bounceAnimDuration = .5f;
        private List<IBouncable> objects;
        private Coroutine bounceAnim;
        #endregion

        #region Core
        public void Initialize()
        {
            objects = new List<IBouncable>();
        }
        #endregion

        #region ListUpdate
        public void AddNewObj(IBouncable obj)
        {
            if (!objects.Contains(obj))
            {
                objects.Add(obj);
            }
        }
        public void RemoveObj(IBouncable obj)
        {
            if (objects.Contains(obj))
            {
                objects.Remove(obj);
            }
        }
        public void ClearObjects() => objects.Clear();
        #endregion

        #region Executes
        public void StartBounceEffect()
        {
            if (bounceAnim != null)
            {
                StopCoroutine(bounceAnim);
            }
            bounceAnim = StartCoroutine(bounceAnimation(bounceDelay));
        }
        private IEnumerator bounceAnimation(float delay)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].BounceAnimation(bounceTargetScale, bounceAnimDuration);
                yield return new WaitForSeconds(delay);
            }
        }
        #endregion
    }
}
