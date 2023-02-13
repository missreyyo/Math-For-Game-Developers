using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class RadialTrigger : MonoBehaviour
{
    public float radius = 1f;
    public Transform playerTransform;
   
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        Vector2 playerPosition = playerTransform.position;  
        float distance = Vector2.Distance(origin,playerPosition);
        bool isInside = distance > radius ? false : true;
        Handles.color = isInside ? Color.green:Color.red;
        Handles.DrawWireDisc(origin,Vector3.forward, radius);
    }
#endif
}
