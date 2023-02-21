using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AdaptiveFoV : MonoBehaviour
{
    public FoVPoint[] points;
    void OnDrawGizmos()
    {
        Camera camera = GetComponent<Camera>();

        Vector2 cameraDirection = camera.transform.forward;
        Vector2 cameraPosition = camera.transform.position;

        float outerMostAngle = float.MinValue;
        Vector2 pointOutermost = default;
        foreach(FoVPoint fovPt in points)
        {
            Vector2 point = (Vector2)fovPt.transform.position - cameraPosition;
            float distanceToPoint = point.magnitude;
            Vector2 directionToPoint = point / distanceToPoint; // normalize
            
            float angleToPoint = Mathf.Acos(Vector2.Dot(cameraDirection,directionToPoint));
            float radiusAngularSpan = Mathf.Asin(fovPt.radius / distanceToPoint );
            float angularDeviation = angleToPoint + radiusAngularSpan;

            if(angleToPoint > outerMostAngle)
            {
                outerMostAngle = angleToPoint;
                pointOutermost = fovPt.transform.position;
            }
            
        }
        
        camera.fieldOfView = outerMostAngle *2 * Mathf.Rad2Deg;
        Gizmos.DrawLine(cameraPosition, pointOutermost);
        DrawPointRadii();
    }
    void DrawPointRadii() { 
    
        foreach(FoVPoint foVPoint in points)
        {
            Gizmos.DrawWireSphere(foVPoint.transform.position, foVPoint.radius);
        }
    }
}
