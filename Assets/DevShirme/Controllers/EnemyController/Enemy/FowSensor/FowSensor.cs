using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.EnemyModule
{
    public class FowSensor: MonoBehaviour
    {
		#region Fields
		private List<Transform> visibleTargets;
		private FowSensorData data;
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

        #region Executes
		public void StartSensor(FowSensorData data)
        {
			this.data = data;
			canSearch = true;
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

					if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, data.ObstacleMask))
					{
						visibleTargets.Add(target);
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
