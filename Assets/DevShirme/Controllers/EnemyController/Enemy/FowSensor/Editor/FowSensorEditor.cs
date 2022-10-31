using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DevShirme.EnemyModule
{
	[CustomEditor(typeof(FowSensor))]
	public class FowSensorEditor : Editor
	{
		void OnSceneGUI()
		{
			FowSensor fow = (FowSensor)target;
			Handles.color = Color.white;
			Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.Data.ViewRadius);
			
			Vector3 viewAngleA = fow.DirFromAngle(-fow.Data.ViewAngle / 2, false);
			Vector3 viewAngleB = fow.DirFromAngle(fow.Data.ViewAngle / 2, false);

			Handles.color = Color.magenta;
			Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.Data.ViewRadius);
			Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.Data.ViewRadius);

			Handles.color = Color.red;

			if (fow.VisibleTargets.Count != 0)
            {
				foreach (Transform visibleTarget in fow.VisibleTargets)
				{
					Handles.DrawLine(fow.transform.position, visibleTarget.position);
				}
			}
			
		}
	}
}

