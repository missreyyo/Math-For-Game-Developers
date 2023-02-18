using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FoV : MonoBehaviour
{
    public Transform obj;
    void OnDrawGizmos()
    {
        Camera camera = GetComponent<Camera>();
        Vector2 reObjectPosition = obj.position - camera.transform.position;

        float opposite = reObjectPosition.y;
        float adjacent = reObjectPosition.x;

        float angleRad = Mathf.Atan(opposite / adjacent);
        camera.fieldOfView = 2* angleRad * Mathf.Rad2Deg;
    }
}
