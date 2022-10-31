using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DevShirme.OwnEditor
{
    [ExecuteInEditMode]
    public class PlacementEditor : EditorWindow
    {
        #region Fields
        private GameObject parentObj;
        private int xDistance;
        private int yDistance;
        private int zDistance;
        #endregion

        #region Open
        [MenuItem("DevShirme/Placement Editor")]
        private static void OpenEditor()
        {
            var window = (PlacementEditor)GetWindow(typeof(PlacementEditor), true, "Placement Editor");
            window.Show();
        }
        #endregion

        #region Core
        public override void SaveChanges()
        {
            base.SaveChanges();
        }
        private void OnGUI()
        {
            GUILayout.Label("Placement Editor");

            EditorGUILayout.BeginVertical();

            parentObj = (GameObject)EditorGUILayout.ObjectField(parentObj, typeof(GameObject), true);
            xDistance = EditorGUILayout.IntField("X Distance", xDistance);
            yDistance = EditorGUILayout.IntField("Y Distance", yDistance);
            zDistance = EditorGUILayout.IntField("Z Distance", zDistance);

            EditorGUILayout.EndVertical();

            if (GUILayout.Button("Place"))
            {
                Place();
                SaveChanges();
            }
        }
        #endregion

        #region Execute
        public void Place()
        {
            for (int i = 0; i < parentObj.transform.childCount; i++)
            {
                Transform obj = parentObj.transform.GetChild(i).transform;
                Vector3 newPos = new Vector3((i * xDistance), (i * yDistance), (i * zDistance));
                obj.SetPositionAndRotation(newPos, Quaternion.identity);
            }
        }
        #endregion

    }
}
