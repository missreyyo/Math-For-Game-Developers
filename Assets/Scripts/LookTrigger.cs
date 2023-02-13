using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LookTrigger : MonoBehaviour
{
    [Range(0f, 1f)]
    public float preciseness = 0.5f;
    public Transform playerTransform;
    void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        Vector2 playerPosition = playerTransform.position;
        Vector2 playerLookDirection = playerTransform.right;
        Vector2 playerToTriggerDirection = (origin - playerPosition).normalized;

        float lookAway = Vector2.Dot(playerToTriggerDirection,playerLookDirection);
        bool isLookAt = lookAway < preciseness ? false : true;
        Gizmos.color = isLookAt ? Color.green : Color.red;
        Gizmos.DrawLine(origin,playerPosition);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(playerPosition,playerPosition + playerLookDirection );

    }
   
}
