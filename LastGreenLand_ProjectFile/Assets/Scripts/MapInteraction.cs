using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInteraction : ButtonInteraction
{
    private void OnDrawGizmos()
    {
        Vector2[] points = GetComponent<PolygonCollider2D>().points;
        Gizmos.color = Color.green;

        for (int i = 0; i < points.Length-1; i++)
        {
            Gizmos.DrawLine(transform.TransformPoint(points[i]), transform.TransformPoint(points[i + 1]));
        }

        Gizmos.DrawLine(transform.TransformPoint(points[points.Length - 1]), transform.TransformPoint(points[0]));
    }
}
