using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace DevShirme.Helpers
{
    public class MeshTransformation : MonoBehaviour
    {
        #region Fields
        [Header("Mesh Transformation Settings")]
        [SerializeField] private DevMesh from;
        [SerializeField] private DevMesh to;
        [SerializeField] private float duration;
        [SerializeField] private AnimationCurve curve;
        private MeshFilter meshFilter;
        private MeshRenderer meshRenderer;
        private Coroutine transformationCorutine;
        private Mesh mesh;
        #endregion

        #region Executes
        [ContextMenu("StartTransformation")]
        public void StartTransformation()
        {
            refresh();

            addComps();

            setMesh(from.GetData());

            transformationCorutine = StartCoroutine(transformation());
        }
        private IEnumerator transformation()
        {
            float t = 0f;

            while (t < duration)
            {
                t += Time.deltaTime;

                yield return null;
            }

            setMesh(to.GetData());
        }
        private void refresh()
        {
            if (transformationCorutine != null)
                StopCoroutine(transformationCorutine);
            if (meshFilter != null)
                meshFilter.mesh = null;
            if (meshRenderer != null)
                meshRenderer.material = null;

            mesh = new Mesh();
        }
        private void addComps()
        {
            if (meshFilter == null)
                meshFilter = gameObject.AddComponent<MeshFilter>();
            if (meshRenderer == null)
                meshRenderer = gameObject.AddComponent<MeshRenderer>();
        }
        private void setMesh(MeshData data)
        {
            mesh.name = data.Name;
            mesh.SetVertices(data.Vertices);
            mesh.SetTriangles(data.Triangles, 0);
            mesh.SetUVs(0, data.UV);
            mesh.SetNormals(data.Normals);
            mesh.SetTangents(data.Tangents);
            meshFilter.mesh = mesh;
        }
        #endregion
    }

    [System.Serializable]
    public class DevMesh
    {
        #region Fields
        [SerializeField] private Mesh mesh;
        private MeshData data;
        #endregion

        #region Getters
        public MeshData GetData()
        {
            data = new MeshData();
            data.Name = mesh.name;
            data.Vertices = mesh.vertices;
            data.Triangles = mesh.triangles;
            data.UV = mesh.uv;
            data.Normals = mesh.normals;
            data.Tangents = mesh.tangents;
            return data;
        }
        #endregion
    }
    public struct MeshData
    {
        public string Name;
        public Vector3[] Vertices;
        public int[] Triangles;
        public Vector2[] UV;
        public Vector3[] Normals;
        public Vector4[] Tangents;
    }
}
