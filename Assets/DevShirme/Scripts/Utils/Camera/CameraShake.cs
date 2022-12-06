using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Utils
{
    public class CameraShake : MonoBehaviour
    {
        public AnimationCurve ShakeCurve = AnimationCurve.EaseInOut(0, 1, 1, 0);
        public float Duration = 2;
        public float Speed = 22;
        public float Magnitude = 1;
        public float RotationDamper = 2;
        public bool StackRotate = false;

        public Vector3 ExtraShakeDirection;
        public float ExtraShakeRand = 2;
        public bool IsDisabled = false;

        bool isPlaying;
        float elapsed = 0.0f;
        Quaternion originalRot;

        public bool IsPlaying
        {
            get { return isPlaying; }
        }

        public void PlayShake()
        {
            if (!IsDisabled)
            {
                originalRot = transform.rotation;
                elapsed = 0;
                isPlaying = true;
                StartCoroutine(shake());
            }
        }

        public void StopShake()
        {
            elapsed = Duration;
            transform.rotation = originalRot;
        }

        IEnumerator shake()
        {
            var originalCamRotation = transform.rotation.eulerAngles;
            var time = 0f;
            var randomStart = Random.Range(-1000.0f, 1000.0f);
            Vector3 oldRotation = Vector3.zero;
            while (elapsed < Duration)
            {
                elapsed += Time.deltaTime;
                var percentComplete = elapsed / Duration;
                var damper = ShakeCurve.Evaluate(percentComplete);
                time += Time.deltaTime * damper;
                transform.position -=
                    transform.forward * Time.deltaTime * Mathf.Sin(time * Speed) * damper * Magnitude / 2 +
                    Random.Range(-ExtraShakeRand, ExtraShakeRand) * ExtraShakeDirection * Time.deltaTime * Mathf.Sin(time * Speed) * damper * Magnitude / 2;


                var alpha = randomStart + Speed * percentComplete / 10;
                var x = Mathf.PerlinNoise(alpha, 0.0f) * 2.0f - 1.0f;
                var y = Mathf.PerlinNoise(1000 + alpha, alpha + 1000) * 2.0f - 1.0f;
                var z = Mathf.PerlinNoise(0.0f, alpha) * 2.0f - 1.0f;

                if (StackRotate)
                    if (Quaternion.Euler(originalCamRotation + oldRotation) != transform.rotation)
                        originalCamRotation = transform.rotation.eulerAngles;

                oldRotation = Mathf.Sin(time * Speed) * damper * Magnitude * new Vector3(0.5f + y, 0.3f + x, 0.3f + z) * RotationDamper;
                transform.rotation = Quaternion.Euler(originalCamRotation + oldRotation);

                yield return null;
            }

            transform.rotation = originalRot;

            isPlaying = false;
        }
    }

}