using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LookTrigger : MonoBehaviour
{
    [Range(0f, 90f)]
    public float angleTresholdDeg = 30f;
    public Transform playerTransform;
    void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        Vector2 playerPosition = playerTransform.position;
        Vector2 playerLookDirection = playerTransform.right;
        Vector2 playerToTriggerDirection = (origin - playerPosition).normalized;

        float dot = Vector2.Dot(playerToTriggerDirection, playerLookDirection);
        dot = Mathf.Clamp(dot, -1, 1);//-1 to 1
        float angleRad = Mathf.Acos(dot);
        float angleTreshRad = angleTresholdDeg * Mathf.Deg2Rad;

        bool isLookAt = angleRad > angleTreshRad ? true : false;
        Gizmos.color = isLookAt ? Color.green : Color.red;
        Gizmos.DrawLine(origin, playerPosition);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(playerPosition, playerPosition + playerLookDirection);

    }

}