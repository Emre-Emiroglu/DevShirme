using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet: MonoBehaviour
{
    #region Fields
    [SerializeField] private float magnetPower;
    private List<Rigidbody> rigidbodies;
    #endregion

    #region Core
    public void Init()
    {
        rigidbodies = new List<Rigidbody>();
    }
    public void Clear() => rigidbodies.Clear();
    #endregion

    #region Update
    private void FixedUpdate()
    {
        if (rigidbodies.Count > 0)
        {
            foreach (Rigidbody rb in rigidbodies)
            {
                rb.AddForce((transform.position - rb.position) * magnetPower * Time.fixedDeltaTime);
            }
        }
    }
    #endregion

    #region Physics
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ballon"))
        {
            Rigidbody rb = other.attachedRigidbody;
            if (!rigidbodies.Contains(rb))
            {
                rigidbodies.Add(rb);
            }
        }
    }
    #endregion
}
