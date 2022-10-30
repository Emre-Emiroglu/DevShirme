using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.CameraModule
{
    public class FollowCamera : Cam
    {
        #region Fields
        [Header("Follow Camera Fields")]
        public Transform Target;
        public float Distance = 10;
        public float Height = 5;
        public float HeightDamping = 2;
        public float PositionDamping = 2;
        public float RotationDamping = 3;
        public float Speed = 1;
        public LookType LookType = LookType.LookTarget;
        public bool LerpRotate = false;
        public Vector3 Rotate = new Vector3(0, 0, 0);
        private Quaternion m_rotation;
        private Vector3 m_latePosition, m_forward;
        private float m_wantedRotAngle, m_wantedH, m_curRotAngle, m_curentH;
        #endregion

        #region Unity
        private void LateUpdate()
        {
            if (UpdateBehavior == UpdateBehavior.Late) updateBase();
        }
        private void FixedUpdate()
        {
            if (UpdateBehavior == UpdateBehavior.Fixed) updateBase();
        }
        private void Update()
        {
            if (UpdateBehavior == UpdateBehavior.Update) updateBase();
        }
        #endregion

        #region Executes
        private void updateBase()
        {
            if (IsActive)
            {
                if (!Target)
                    return;

                m_wantedRotAngle = Target.eulerAngles.y;
                m_wantedH = Target.position.y + Height;

                m_curRotAngle = transform.eulerAngles.y;
                m_curentH = transform.position.y;

                m_curRotAngle = Mathf.LerpAngle(m_curRotAngle, m_wantedRotAngle, RotationDamping * Time.deltaTime);
                m_curentH = Mathf.Lerp(m_curentH, m_wantedH, HeightDamping * Time.deltaTime);

                m_rotation = Quaternion.Euler(0, m_curRotAngle, 0);

                m_latePosition = Target.position;

                m_latePosition -= m_rotation * (Vector3.forward * Speed) * Distance;
                m_latePosition.x = Mathf.Lerp(transform.position.x, m_latePosition.x, PositionDamping * Time.deltaTime);

                if (Vector3.Distance(transform.position, m_latePosition) > 0.1f)
                    m_latePosition.z = Mathf.Lerp(transform.position.z, m_latePosition.z, PositionDamping * Time.deltaTime);

                transform.position = new Vector3(m_latePosition.x, m_curentH, m_latePosition.z);

                switch (LookType)
                {
                    case LookType.LookTarget:
                        if (LerpRotate) m_forward = Vector3.Lerp(m_forward, Target.position + Rotate, RotationDamping);
                        else m_forward = Target.position + Rotate;

                        transform.LookAt(m_forward);
                        break;

                    case LookType.LookFixed:
                        if (LerpRotate) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Rotate.x, Rotate.y, Rotate.z), 0.1f);
                        else transform.eulerAngles = Rotate;

                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

    }
}