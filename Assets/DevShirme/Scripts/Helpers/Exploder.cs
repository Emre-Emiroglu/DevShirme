using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DevShirme.Helpers
{
    public class Exploder : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private List<Rigidbody> pieces;
        [SerializeField] private float radius;
        [SerializeField] private float force;
        [SerializeField] private float upwardModifier;
        [SerializeField] private Vector3 explosionPosOffset;
        [Header("Gizmos Settings")]
        [SerializeField] private Color gizmoColor;
        private Vector3[] poses;
        private Quaternion[] rots;
        #endregion

        #region Executes
        private void Awake()
        {
            Init();
        }
        public void Init()
        {
            poses = new Vector3[pieces.Count];
            rots = new Quaternion[pieces.Count];

            for (int i = 0; i < pieces.Count; i++)
            {
                poses[i] = pieces[i].transform.localPosition;
                rots[i] = pieces[i].transform.localRotation;
            }
        }
        [ContextMenu("Explode")]
        public void Explode()
        {
            SetPiecesPhysic(true);

            Vector3 explosionPos = transform.position + explosionPosOffset;
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            pieces.ForEach(x => x.AddExplosionForce(force, explosionPos, radius, upwardModifier));
        }
        [ContextMenu("Refresh")]
        public void Refresh()
        {
            SetPiecesPhysic(false);
            for (int i = 0; i < pieces.Count; i++)
            {
                //pieces[i].transform.localPosition = poses[i];
                //pieces[i].transform.localRotation = rots[i];
                StartCoroutine(Test(2f, pieces[i].transform, poses[i], rots[i]));
            }
        }
        private void SetPiecesPhysic(bool isActive)
        {
            pieces.ForEach(x =>
            {
                x.isKinematic = !isActive;
                x.useGravity = isActive;
            });
        }
        private IEnumerator Test(float duration, Transform piece, Vector3 newPos, Quaternion newRot)
        {
            float t = 0f;
            Vector3 oldPos = piece.transform.localPosition;
            Quaternion oldRot = piece.transform.localRotation;
            while (t < duration)
            {
                t += Time.deltaTime;
                piece.transform.localPosition = Vector3.Lerp(oldPos, newPos, t / duration);
                piece.transform.localRotation = Quaternion.Lerp(oldRot, newRot, t / duration);
                yield return null;
            }
        }
        #endregion

        #region Gizmos
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
        #endregion
    }
}
