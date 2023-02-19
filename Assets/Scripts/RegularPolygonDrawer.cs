using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularPolygonDrawer : MonoBehaviour
{
    [Range(3,12)]
    public int sideCount = 4;
    [Range(1,4)]
    public int density = 1;
    const float TAU = 6.28318350718f;
    Vector2 AngleToDirection(float angleRad) => new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    float DirectionToAngle(Vector2 vector) => Mathf.Atan2(vector.y, vector.x);
    void OnDrawGizmos()
    {
        Vector2[] vertices = new Vector2[sideCount];
        for(int i = 0; i< sideCount; i++)
        {
            vertices[i] = AngleToDirection(i * TAU/sideCount);
        }
        //Drawing point 
        Gizmos.color = Color.green;
        for( int j = 0; j < sideCount; j++)
        {
            Gizmos.DrawSphere(vertices[j], 0.5f);
        }
        //Drawing lines
        Gizmos.color = Color.red;
        for (int a = 0; a < sideCount; a++)
        {
            Gizmos.DrawLine(vertices[a], vertices[(a+density)%sideCount]);
        }

    }
}
