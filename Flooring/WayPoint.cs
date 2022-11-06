using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Tower towerMain;
    
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = towerMain.CreateTower(towerMain, transform.position);
            isPlaceable = !isPlaced;
        }
        else { Debug.Log("Not Placeable"); }
    }

}
