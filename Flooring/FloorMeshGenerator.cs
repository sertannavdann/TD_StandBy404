using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMeshGenerator : MonoBehaviour
{
    [SerializeField] GameObject path;
    [SerializeField] GameObject floor;

    [SerializeField] GameObject env;

    WayPoint wayPoint;
    void Awake() 
    {
        Vector3 parentPos = transform.parent.position;
        wayPoint = GetComponentInParent<WayPoint>();
        // Instantiate path or floor and put it inside the env
        if (wayPoint.IsPlaceable)
        {   
            Instantiate(path, parentPos, Quaternion.identity);
        } else
        {
            Instantiate(floor, parentPos, Quaternion.identity);
        }
    }
}
