using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Helpers
{
    public class MeshDrawer : MonoBehaviour
    {
        #region Fields
        [Header("Drawing Settings")]
        [SerializeField] private float threshold = .1f;
        [SerializeField] private GameObject drawResult;
        [Header("Components")]
        [SerializeField] private LineRenderer lr;
        [SerializeField] private MeshCollider drawQuad;
        private List<Vector3> fingerPoses;
        private bool canDraw;
        #endregion

        #region Core
        private void Awake()
        {
            fingerPoses = new List<Vector3>();
        }
        #endregion

        #region Receivers
        private void onInputStarted(Vector3 mouseWorldPos)
        {
            lr.positionCount = 2;
            for (int i = 0; i < 2; i++)
            {
                fingerPoses.Add(mouseWorldPos);
                lr.SetPosition(i, fingerPoses[i]);
            }
        }
        private void onInputEnded()
        {
            lineToMesh();
            fingerPoses.Clear();
            lr.positionCount = 0;
        }
        #endregion

        #region Calculatse
        private float calculateXOffset(Vector3[] vertices)
        {
            float xOffset = 0f;
            foreach (Vector3 v in vertices)
            {
                xOffset += v.x;
            }
            xOffset /= vertices.Length;
            return xOffset * -1f;
        }
        #endregion

        #region Setters
        private void setDrawResult(Mesh mesh)
        {
            drawResult.GetComponent<MeshFilter>().sharedMesh = mesh;
            drawResult.GetComponent<MeshCollider>().sharedMesh = mesh;
            drawResult.GetComponent<MeshCollider>().convex = true;
        }
        #endregion

        #region Executes
        private void drawLine(Vector3 mouseWorldPos)
        {
            float diff = Mathf.Sqrt(Vector3.SqrMagnitude(mouseWorldPos - fingerPoses[fingerPoses.Count - 1]));
            if (diff > threshold)
            {
                fingerPoses.Add(mouseWorldPos);
                lr.positionCount++;
                lr.SetPosition(lr.positionCount - 1, mouseWorldPos);
            }
        }
        private void lineToMesh()
        {
            Mesh mesh = new Mesh();
            lr.BakeMesh(mesh, true);

            manipulateVertices(mesh);
            setDrawResult(mesh);
        }
        private void manipulateVertices(Mesh mesh)
        {
            Vector3[] vertices = mesh.vertices;

            float xOffsett = calculateXOffset(vertices);

            for (int i = 0; i < vertices.Length; i++)
            {
                float x = vertices[i].x + xOffsett;
                float y = vertices[i].y + 3;
                float z = vertices[i].z;
                Vector3 newVertices = new Vector3(x, y, z);
                vertices[i] = newVertices;
            }
            mesh.vertices = vertices;

            mesh.RecalculateBounds();
            mesh.Optimize();
        }
        #endregion

        #region Updates
        public void ExternalUpdate(Vector3 mouseWorldPos, bool isInputActive)
        {
            canDraw = drawQuad.bounds.Contains(mouseWorldPos);
            if (canDraw && isInputActive)
            {
                drawLine(mouseWorldPos);
            }
        }
        #endregion
    }
}
