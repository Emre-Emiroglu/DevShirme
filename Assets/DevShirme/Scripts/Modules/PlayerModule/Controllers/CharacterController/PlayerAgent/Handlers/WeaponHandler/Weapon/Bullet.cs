using DevShirme.Managers.PoolManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolObject
{
    #region Fields
    private Rigidbody rb;
    #endregion

    #region Core
    public override void Initialize()
    {
        base.Initialize();

        rb = GetComponent<Rigidbody>();
    }
    public override void Spawn(Vector3 pos, Quaternion rot, Vector3 scale, Transform parent, bool useRotation = false, bool useScale = false, bool setParent = false)
    {
        base.Spawn(pos, rot, scale, parent, useRotation, useScale, setParent);
    }
    public override void DeSpawn()
    {
        base.DeSpawn();

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
    #endregion

    #region Executes
    public void Throw(float speed, ForceMode forceMode) => rb.AddRelativeForce(Vector3.forward * speed, forceMode);
    #endregion
}
