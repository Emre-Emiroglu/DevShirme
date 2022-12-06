using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace DevShirme.Utils
{
    public static class Utilities
    {
        public static void CreateTag(string tag)
        {
#if UNITY_EDITOR
            var asset = AssetDatabase.LoadMainAssetAtPath("ProjectSettings/TagManager.asset");
            if (asset != null)
            { // sanity checking
                var so = new SerializedObject(asset);
                var tags = so.FindProperty("tags");

                var numTags = tags.arraySize;
                // do not create duplicates
                for (int i = 0; i < numTags; i++)
                {
                    var existingTag = tags.GetArrayElementAtIndex(i);
                    if (existingTag.stringValue == tag) return;
                }

                tags.InsertArrayElementAtIndex(numTags);
                tags.GetArrayElementAtIndex(numTags).stringValue = tag;
                so.ApplyModifiedProperties();
                so.Update();
            }
#endif
        }
        public static IEnumerator SetCanvasGroupAlpha(CanvasGroup canvasGroup, float targetValue, float duration = 1f)
        {
            float t = 0f;
            float startValue = canvasGroup.alpha;
            while (t < 1f)
            {
                t += Time.deltaTime / duration;
                canvasGroup.alpha = Mathf.Lerp(startValue, targetValue, t);
                yield return null;
            }
        }
        public static Vector3 WorldToScreenPointForUICamera(Vector3 worldPos, Camera GameCamera, Canvas ScreenCanvas)
        {
            Vector3 screenPos;
            Vector3 canvasPos;
            Vector2 posRect2D;

            screenPos = GameCamera.WorldToScreenPoint(worldPos);

            if (ScreenCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                canvasPos = screenPos;
            }
            else
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                ScreenCanvas.transform as RectTransform, screenPos, ScreenCanvas.worldCamera, out posRect2D);
                canvasPos = ScreenCanvas.transform.TransformPoint(posRect2D);
            }

            return canvasPos;
        }
        public static List<T> Shuffle<T>(this List<T> ts)
        {
            var result = ts;
            var count = ts.Count;
            var last = count - 1;
            for (int i = 0; i < last; i++)
            {
                var r = Random.Range(i, count);
                var tmp = ts[i];
                ts[i] = ts[r];
                ts[r] = tmp;
            }
            return result;
        }
        public static void BubbleSort(this IList<int> ts)
        {
            int count = ts.Count;
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - 1; j++)
                {
                    if (ts[j] > ts[j + 1])
                    {
                        int tmp = ts[j];
                        ts[j] = ts[j + 1];
                        ts[j + 1] = tmp;
                    }
                }
            }
        }
    }
}
