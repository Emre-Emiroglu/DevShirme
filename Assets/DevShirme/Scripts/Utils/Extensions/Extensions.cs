using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace DevShirme.Utils
{
    public static class Extensions
    {
        public static T GetCopyOf<T>(this Component comp, T other) where T : Component
        {
            Type type = comp.GetType();
            if (type != other.GetType()) return null; // type mis-match
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
            PropertyInfo[] pinfos = type.GetProperties(flags);
            foreach (var pinfo in pinfos)
            {
                if (pinfo.CanWrite)
                {
                    try
                    {
                        pinfo.SetValue(comp, pinfo.GetValue(other, null), null);
                    }
                    catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
                }
            }
            FieldInfo[] finfos = type.GetFields(flags);
            foreach (var finfo in finfos)
            {
                finfo.SetValue(comp, finfo.GetValue(other));
            }
            return comp as T;
        }
        public static T AddComponent<T>(this GameObject gameObject, T toAdd) where T : Component
        {
            return gameObject.AddComponent<T>().GetCopyOf(toAdd) as T;
        }
        public static Transform SetX(this Transform transform, float x, bool local)
        {
            if (local)
            {
                transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
            }
            else
            {
                transform.position = new Vector3(x, transform.position.y, transform.position.z);
            }
            return transform;
        }
        public static Transform SetY(this Transform transform, float y, bool local)
        {
            if (local)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, y, transform.position.z);
            }
            return transform;
        }
        public static Transform SetZ(this Transform transform, float z, bool local)
        {
            if (local)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, z);
            }
            return transform;
        }
        public static Transform SetXY(this Transform transform, float x, float y, bool local)
        {
            if (local)
            {
                transform.localPosition = new Vector3(x, y, transform.localPosition.z);
            }
            else
            {
                transform.position = new Vector3(x, y, transform.position.z);
            }
            return transform;
        }
        public static Transform SetXZ(this Transform transform, float x, float z, bool local)
        {
            if (local)
            {
                transform.localPosition = new Vector3(x, transform.localPosition.y, z);
            }
            else
            {
                transform.position = new Vector3(x, transform.position.y, z);
            }
            return transform;
        }
        public static Transform SetYZ(this Transform transform, float y, float z, bool local)
        {
            if (local)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, y, z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, y, z);
            }
            return transform;
        }
        public static Transform SetXYZ(this Transform transform, float x, float y, float z, bool local)
        {
            if (local)
            {
                transform.localPosition = new Vector3(x, y, z);
            }
            else
            {
                transform.position = new Vector3(x, y, z);
            }
            return transform;
        }
        public static void LookAtWithX(this Transform transform, Transform target)
        {
            transform.LookAt(target);
            transform.Rotate(Vector3.down * 90, Space.Self);
        }
        public static void LookAtWithX(this Transform transform, Vector3 target)
        {
            transform.LookAt(target);
            transform.Rotate(Vector3.down * 90, Space.Self);
        }
        public static void LookAtWithY(this Transform transform, Transform target)
        {
            transform.LookAt(target);
            transform.Rotate(Vector3.right * 90, Space.Self);
        }
        public static void LookAtWithY(this Transform transform, Vector3 target)
        {
            transform.LookAt(target);
            transform.Rotate(Vector3.right * 90, Space.Self);
        }
        public static void LookAtGradually(this Transform transform, Transform target, float maxRadiansDelta, bool stableUpVector = false)
        {
            Vector3 dir = target.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, maxRadiansDelta, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDir);
            if (stableUpVector)
            {
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
            }
        }
        public static void LookAtGradually(this Transform transform, Vector3 target, float maxRadiansDelta, bool stableUpVector = false)
        {
            Vector3 dir = target - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, maxRadiansDelta, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDir);
            if (stableUpVector)
            {
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
            }
        }
        public static void LookAtWithXGradually(this Transform transform, Transform target, float maxRadiansDelta)
        {
            Vector3 dir = target.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.right, dir, maxRadiansDelta, 0.0f);

            transform.LookAtWithX(newDir);
        }
        public static void LookAtWithXGradually(this Transform transform, Vector3 target, float maxRadiansDelta)
        {
            Vector3 dir = target - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.right, dir, maxRadiansDelta, 0.0f);

            transform.LookAtWithX(newDir);
        }
        public static void LookAtWithYGradually(this Transform transform, Transform target, float maxRadiansDelta)
        {
            Vector3 dir = target.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.up, dir, maxRadiansDelta, 0.0f);

            transform.LookAtWithY(newDir);
        }
        public static void LookAtWithYGradually(this Transform transform, Vector3 target, float maxRadiansDelta)
        {
            Vector3 dir = target - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.up, dir, maxRadiansDelta, 0.0f);

            transform.LookAtWithY(newDir);
        }
        public static Transform FindRecursive(this Transform transform, string name, bool includeInactive = false)
        {
            foreach (Transform child in transform.GetComponentsInChildren<Transform>(includeInactive))
            {
                if (child.name.Equals(name))
                {
                    return child;
                }
            }
            return null;
        }
    }
}
