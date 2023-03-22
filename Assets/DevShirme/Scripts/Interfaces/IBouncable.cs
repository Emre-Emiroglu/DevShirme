using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBouncable
{
    public void BounceAnimation(float targetScale, float duration);
    public IEnumerator bounceAnim(float targetScale, float duration);
}
