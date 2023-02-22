using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public Transform startTransform;
    public Transform endTransform;

    [Range(0f, 1f)]
    public float t = 0;

    void OnDrawGizmos()
    {
        Vector3 a = startTransform.position;
        Vector3 b = endTransform.position;

        Vector3 point = Vector3.Lerp(a, b, t);
        Gizmos.color = Color.Lerp(Color.green, Color.red, t);
        Gizmos.DrawLine(a, b);
        Gizmos.DrawSphere(point, 0.2f);
    }
}
