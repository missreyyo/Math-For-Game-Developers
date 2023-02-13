using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SpaceTransform : MonoBehaviour
{
    public Vector2 localSpacePoint;
    void OnDrawGizmos()
    {
        Vector2 playerPosition = transform.position;
        Vector2 right = transform.right;
        Vector2 up = transform.up;

        Vector2 LocalToWorld(Vector2 localPoint)
        {
            Vector2 localWorldOffSet = right * localSpacePoint.x + up *localSpacePoint.y;
            return (Vector2)transform.position + localWorldOffSet;
        }
       
        Vector2 worldSpacePoint = LocalToWorld(localSpacePoint) ;
        DrawBasisVectors(playerPosition, right, up);
        DrawBasisVectors(Vector2.zero,Vector2.right,Vector2.up);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(localSpacePoint,0.1f);
    }

   
    void DrawBasisVectors(Vector2 position, Vector2 right,  Vector2 up)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(position,right);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(position, up);
        Gizmos.color = Color.white;
    }
}
