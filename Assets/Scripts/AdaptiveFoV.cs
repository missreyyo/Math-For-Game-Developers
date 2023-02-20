using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptiveFoV : MonoBehaviour
{
    public Transform[] points;
    void OnDrawGizmos()
    {
        Camera camera = GetComponent<Camera>();

        Vector2 cameraDirection = camera.transform.forward;
        Vector2 cameraPosition = camera.transform.position;

        float lowestDotProduct = float.MaxValue;
        Vector2 pointOutermost = default;
        foreach(Transform pointTransform in points)
        {
            Vector2 point = (Vector2)pointTransform.position - cameraPosition;
            Vector2 directionToPoint = point.normalized;
            float dot = Vector2.Dot(cameraDirection,directionToPoint);
            if(dot< lowestDotProduct)
            {
                lowestDotProduct = dot;
                pointOutermost = pointTransform.position;
            }
            
        }
        float angRad = Mathf.Acos(lowestDotProduct);
        camera.fieldOfView = angRad *2 * Mathf.Rad2Deg;
        Gizmos.DrawLine(cameraPosition, pointOutermost);


    }
}
