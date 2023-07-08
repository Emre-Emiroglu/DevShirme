using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DesignPatterns.BehavioralPatterns.CommandPattern
{
    public class MoveObject : MonoBehaviour
    {
        #region Fields
        private float stepDist = 1f;
        #endregion

        #region Executes
        public void MoveForward()
        {
            Move(Vector3.forward);
        }
        public void MoveBack()
        {
            Move(Vector3.back);
        }
        public void TurnLeft()
        {
            Move(Vector3.left);
        }
        public void TurnRight()
        {
            Move(Vector3.right);
        }
        private void Move(Vector3 dir)
        {
            transform.Translate(dir * stepDist);
        }
        #endregion
    }
}
