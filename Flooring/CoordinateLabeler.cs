using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color32 defaultColor = new Color
    {
        r = 1f,
        g = 1f,
        b = 1f,
        a = 0.75f
    };
    [SerializeField] Color32 blockedColor = new Color
    {
        r = 1f,
        g = 0f,
        b = 0f
    };

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    WayPoint wayPoint;

    void Awake()
    {
        wayPoint = GetComponentInParent<WayPoint>();
        label = GetComponent<TextMeshPro>();

        //Debug.Log(label.faceColor);
    }
    void Update()
    {

        DisplayCordinates();
        UpdateObjectName();

        ToggleLabels();
        SetColor();
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void SetColor()
    {
        if (wayPoint.IsPlaceable)
        {
            label.faceColor = defaultColor;
        }
        else
        {
            label.faceColor = blockedColor;
        }
    }
    void DisplayCordinates() 
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.x);
        label.text =  coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
