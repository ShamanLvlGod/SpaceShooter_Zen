using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryProvider : MonoBehaviour
{
    [SerializeField] private Bounds bounds;

    public Bounds Bounds => bounds;

    private void Start()
    {

    }

    private bool IsInsideBoundary(Vector3 point)
    {
        return bounds.Contains(point);
    }

    public Vector3 GetClosest(Vector3 point)
    {
        if (IsInsideBoundary(point))
        {
            return point;
        }

        Vector3 closest = bounds.ClosestPoint(point);
        return new Vector3(closest.x, point.y, closest.z);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.2f);
        Gizmos.DrawCube(bounds.center, bounds.extents * 2);
    }
}