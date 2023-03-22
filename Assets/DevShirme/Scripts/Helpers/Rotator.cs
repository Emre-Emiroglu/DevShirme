using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    #region Fields
    [SerializeField] private Vector3 axis;
    [SerializeField] private float speed;
    private bool isActive;
    #endregion

    #region Props
    public bool IsActive { get; set; }
    #endregion

    #region Executes
    private void rotate()
    {
        transform.Rotate(axis, speed * Time.deltaTime);
    }
    #endregion

    #region Update
    private void Update()
    {
        if (IsActive)
        {
            rotate();
        }
    }
    #endregion
}
