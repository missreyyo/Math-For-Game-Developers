using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LookTrigger : MonoBehaviour
{
    [Range(0f, 180f)]
    public float angleTresholdDeg = 30f;

    public Transform playerTransform;

    const float TAU = 6.28318530718f;
    Vector2 AngToDir(float angRad)
    {
        return new Vector2(Mathf.Cos(angRad), Mathf.Sin(angRad));
    }
    float DirToAng(Vector2 vector)
    {
        return Mathf.Atan2(vector.y, vector.x);
    }
    public int count = 128;
    void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        Vector2 playerPosition = playerTransform.position;
        Vector2 playerToTriggerDirection = (origin - playerPosition).normalized;
        //    Handles.DrawWireArc(playerPosition,Vector3.forward,playerToTriggerDirection,1f);  wire example
        for (int i = 0; i < count; i++)
             {
                 float t = i / (float)count;
                 float angRad = t * Mathf.PI * 2;
                 Vector2 dir = AngToDir(angRad);
                 DrawLookLine(dir);
             }  
        
    }
    void DrawLookLine(Vector2 lookDir)
    {   
        Vector2 origin = transform.position;
        Vector2 playerPosition = playerTransform.position;
        Vector2 playerToTriggerDirection = (origin - playerPosition).normalized;
        float dot = Vector2.Dot(playerToTriggerDirection, lookDir);
        dot = Mathf.Clamp(dot, -1, 1);//-1 to 1
        float angleRad = Mathf.Acos(dot);
        float angleTreshRad = angleTresholdDeg * Mathf.Deg2Rad;

        bool isLookAt = angleRad < angleTreshRad ? true : false;
        Gizmos.color = isLookAt ? Color.green : Color.red;
        Gizmos.DrawLine(playerPosition, playerPosition+lookDir);
        
    }

}