using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevShirme.EnemyModule
{
	public class FowSensor : MonoBehaviour
	{
		#region Fields
		public Action<Transform> OnDetected;
		[Header("Sensor Fields")]
		[SerializeField] private FowSensorData data;
		[SerializeField] private List<Transform> visibleTargets;
		private bool canSearch;
		private Coroutine search;
		#endregion

		#region Getters
		public List<Transform> VisibleTargets => visibleTargets;
		public FowSensorData Data => data;
		public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
		{
			if (!angleIsGlobal)
			{
				angleInDegrees += transform.eulerAngles.y;
			}
			return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
		}
        #endregion

        #region Core
		public void Initialize()
        {
        }
        #endregion

        #region Executes
        public void StartSensor()
        {
			canSearch = true;
			visibleTargets = new List<Transform>();
			search = StartCoroutine(searching(data.SearchDelay));
		}
		public void StopSensor()
        {
			canSearch = false;
			if (search != null)
			{
				StopCoroutine(search);
			}
		}
		private void findVisibleTargets()
		{
			visibleTargets.Clear();
			Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, data.ViewRadius, data.TargetMask);

			for (int i = 0; i < targetsInViewRadius.Length; i++)
			{
				Transform target = targetsInViewRadius[i].transform;
				Vector3 dirToTarget = (target.position - transform.position).normalized;
				if (Vector3.Angle(transform.forward, dirToTarget) < data.ViewAngle / 2)
				{
					float dstToTarget = Vector3.Distance(transform.position, target.position);

					if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, data.ObstacleMask) && !visibleTargets.Contains(target))
					{
						visibleTargets.Add(target);
						OnDetected?.Invoke(target);
					}
				}
			}
		}
		private IEnumerator searching(float delay)
		{
			while (canSearch)
			{
				yield return new WaitForSeconds(delay);
				findVisibleTargets();
			}
		}
		#endregion
	}
}

[Serializable]
public struct FowSensorData
{
	#region Fields
	[Header("Sensor Settings")]
	[SerializeField] private float viewRadius;
	[SerializeField] private float viewAngle;
	[SerializeField] private float searchDelay;
	[SerializeField] private LayerMask targetMask;
	[SerializeField] private LayerMask obstacleMask;
	#endregion

	#region Getters
	public float ViewRadius => viewRadius;
	public float ViewAngle => viewAngle;
	public float SearchDelay => searchDelay;
	public LayerMask TargetMask => targetMask;
	public LayerMask ObstacleMask => obstacleMask;
	#endregion
}