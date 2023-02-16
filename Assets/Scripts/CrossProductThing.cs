using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class CrossProductThing : MonoBehaviour
{
    public Mesh mesh;
    public float area = 0f;

    void OnValidate()
    {
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;
        area = 0f;
        for (int i = 0; i < triangles.Length; i+= 3) {
            Vector3 a = vertices[triangles[i]];
            Vector3 b = vertices[triangles[i+1]];
            Vector3 c = vertices[triangles[i+2]];
            area += Vector3.Cross(b - a,c-a).magnitude;
        }
        area /= 2;
    }
    void OnDrawGizmos()
    {
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i += 3)
        {
            Gizmos.DrawSphere(transform.TransformPoint(vertices[i]), 0.01f);
        }
        Vector3 headPos = transform.position;
        Vector3 lookDir = transform.forward;
        void DrawRay (Vector3 position, Vector3 direction)  => Handles.DrawAAPolyLine(position, position+direction);
        if (Physics.Raycast(headPos, lookDir, out RaycastHit hit))
        {
            Vector3 hitPos = hit.point;
            Vector3 up = hit.normal;
            Vector3 right = Vector3.Cross(up,lookDir).normalized;
            Vector3 forward = Vector3.Cross(right, up);
            Quaternion turretRotation = Quaternion.LookRotation(forward,up);
            Matrix4x4 turretToWorld = Matrix4x4.TRS(hitPos,turretRotation,Vector3.one);
            
            Vector3[] points = new Vector3[]
            {
                new Vector3(1,0,1),
                new Vector3(-1,0,1),
                new Vector3(-1,0,-1),
                new Vector3(1,0,-1),
                new Vector3(1,2,1),
                new Vector3(-1,2,1),
                new Vector3(-1,2,-1),
                new Vector3(1,2,-1),
            };
            Gizmos.matrix = turretToWorld;

            Gizmos.color = Color.red;
            for (int i = 0; i < points.Length; i++)
            {
                Gizmos.DrawSphere(points[i], 0.05f);
            }

            Handles.color = Color.white;
            Handles.DrawAAPolyLine(EditorGUIUtility.whiteTexture,5,headPos, hitPos);

            Handles.color = Color.green;
            DrawRay(Vector3.zero, Vector3.right);

            Handles.color = Color.red;
            DrawRay(Vector3.zero, Vector3.up);

            Handles.color = Color.yellow;
            DrawRay(Vector3.zero, Vector3.forward);
            Gizmos.matrix = Matrix4x4.identity;
        }
        else
        {
            Handles.color = Color.red;
            DrawRay(headPos, lookDir);

        }
    }
}
