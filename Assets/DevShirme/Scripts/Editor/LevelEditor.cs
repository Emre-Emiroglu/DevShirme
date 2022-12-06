using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LevelEditor : EditorWindow
{
    #region Fields
    private Sprite reference;
    private GameObject piecePrefab;
    private GameObject parent;
    private int resolution;
    #endregion

    #region Core
    [MenuItem("DevShirme/LevelEditor")]
    private static void Init()
    {
        LevelEditor levelEditor = (LevelEditor)GetWindow(typeof(LevelEditor));
        levelEditor.minSize = new Vector2(540f, 180f);
        levelEditor.maxSize = new Vector2(540f, 180f);
        levelEditor.Show();
    }
    void OnGUI()
    {
        GUILayout.Label("Level Editor", EditorStyles.boldLabel);

        GUILayout.BeginVertical();

        #region Selections
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Referance Sprite");
        reference = (Sprite)EditorGUILayout.ObjectField(reference, typeof(Sprite), false);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Piece Prefab");
        piecePrefab = (GameObject)EditorGUILayout.ObjectField(piecePrefab, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Parent Object");
        parent = (GameObject)EditorGUILayout.ObjectField(parent, typeof(GameObject), true);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Resolution");
        resolution = EditorGUILayout.IntSlider(resolution, 8, 512);
        EditorGUILayout.EndHorizontal();
        #endregion

        GUILayout.EndVertical();

        #region Buttons
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Generate"))
        {
            bool canGenerate = piecePrefab != null && reference != null;

            if (piecePrefab == null)
                Debug.LogError("Piece Prefab Cannot Be Empty");
            if (reference == null)
                Debug.LogError("Sprite Referance Cannot Be Empty");

            if (canGenerate)
                generateLevel();
        }

        GUILayout.EndHorizontal();
        #endregion
    }
    #endregion

    #region Generations
    private void generateLevel()
    {
        int index = 0;

        int width = reference.texture.width;
        int height = reference.texture.height;
        int xAmount = width / resolution;
        int zAmount = height / resolution;
        int xCount = width / xAmount;
        int zCount = height / zAmount;

        Vector3 centerOffset = new Vector3(-xCount * .5f, 0f, -zCount * .5f);

        for (int x = 0; x < width; x += xAmount)
        {
            for (int z = 0; z < height; z += zAmount)
            {
                Color color = reference.texture.GetPixel(x, z);
                if (color.a != 0)
                {
                    Vector3 spawnPos = new Vector3(x / xAmount, 0f, z / zAmount) + centerOffset;
                    spawn(index, spawnPos, color);
                    index++;
                }
            }
        }
    }
    private void spawn(int index, Vector3 pos, Color newColor)
    {
        GameObject piece = Instantiate(piecePrefab, pos, Quaternion.identity);
        piece.transform.SetParent(parent.transform);
        piece.name = "Piece-" + index;

        MeshRenderer mr = piece.GetComponentInChildren<MeshRenderer>();
        Material orgMat = mr.sharedMaterial;
        Material cloneMat = Instantiate(orgMat);
        cloneMat.color = newColor;
        mr.sharedMaterial = cloneMat;
    }
    #endregion

}
