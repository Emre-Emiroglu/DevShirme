using UnityEngine;

namespace DevShirme.CameraModule
{
    public class PlaneCamera : Cam
    {
        #region Fields
        [Header("Plane Camera Fields")]
        public Vector3 Pivot;
        public float MoveLerp = 0.1f, RotateLerp = 0.1f;
        public float HMax = 70, HMin = 20;
        public Vector2 MaxBounds = new Vector3(10, 5);
        public Vector2 MinBounds = new Vector3(10, 5);
        public Vector2 ZoomAddMax = new Vector3(10, 5);
        public Vector2 ZoomAddMin = new Vector3(10, 5);
        public Vector3 ZoomRotateMax = new Vector3(-15, 0, 0);
        [HideInInspector]
        public Vector3 Position;
        private Vector3 clampBounderMax, clampBounderMin, rotation;
        private float percent;
        private Vector3 defaultRot;
        #endregion

        #region Unity
        private void Start()
        {
            Position = transform.position;
            defaultRot = transform.eulerAngles;
            rotation = defaultRot;
        }
        private void Update()
        {
            behaviorUpdate();

            if (UpdateBehavior == UpdateBehavior.Update) movementUpdate();
        }
        private void FixedUpdate()
        {
            if (UpdateBehavior == UpdateBehavior.Fixed) movementUpdate();
        }
        private void LateUpdate()
        {
            if (UpdateBehavior == UpdateBehavior.Late) movementUpdate();
        }
        #endregion

        #region Executes
        public void SetPositionImmediate(Vector3 pos)
        {
            Position = pos;
            transform.position = pos;
        }
        private void movementUpdate()
        {
            if (IsActive)
            {
                if (Vector3.Distance(transform.position, Position) > 0.5f)
                    transform.position = Vector3.Lerp(transform.position, Position, MoveLerp);

                if (Vector3.Distance(transform.eulerAngles, rotation) > 0.1f)
                    transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, rotation, RotateLerp);
            }
        }
        private void behaviorUpdate()
        {
            percent = (Position.y - HMin) / (HMax - HMin);
            rotation = defaultRot + (ZoomRotateMax * (1f - percent));

            clampBounderMax.z = Pivot.z + (MaxBounds.y + (ZoomAddMax.y * (1 - percent)));
            clampBounderMin.z = Pivot.z - (MinBounds.y + (ZoomAddMin.y * (1 - percent)));
            clampBounderMax.x = Pivot.x + (MaxBounds.x + (ZoomAddMax.x * (1 - percent)));
            clampBounderMin.x = Pivot.x - (MinBounds.x + (ZoomAddMin.x * (1 - percent)));

            clampBounderMin.y = HMin;
            clampBounderMax.y = HMax;

            if (Position.x > clampBounderMax.x) Position.x = clampBounderMax.x;
            if (Position.z > clampBounderMax.z) Position.z = clampBounderMax.z;
            if (Position.y > clampBounderMax.y) Position.y = clampBounderMax.y;

            if (Position.x < clampBounderMin.x) Position.x = clampBounderMin.x;
            if (Position.z < clampBounderMin.z) Position.z = clampBounderMin.z;
            if (Position.y < clampBounderMin.y) Position.y = clampBounderMin.y;
        }
        #endregion
    }
}