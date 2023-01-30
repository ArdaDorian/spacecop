using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosDrawer : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Vector2 startPos = transform.GetChild(0).position;
        Vector2 prevPos;
        prevPos = startPos;

        foreach (Transform child in transform)
        {
            Gizmos.DrawLine(prevPos, child.position);
            prevPos= child.position;
        }
    }
}
