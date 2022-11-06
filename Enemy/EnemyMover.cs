using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField][Range(0f, 3f)] float speed = 1f;

    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        Debug.Log("Start Here");
        FindPath();
        ReturnStart();
        StartCoroutine(FollowPath());
        
        //InvokeRepeating("PrintWaypointName", 0, 1f);
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        int count = parent.transform.childCount;

        GameObject[] tiles = new GameObject[count];

        for (int i = 0; i < count; i++) 
        {
            tiles[i] = parent.transform.GetChild(i).gameObject;

            WayPoint waypoint = tiles[i].GetComponent<WayPoint>();
            if (waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    void ReturnStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath() {
        Debug.Log("End Here");
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach(WayPoint wayPoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = wayPoint.transform.position;
            
            /*
            Quaternion startRot = transform.rotation;
            Quaternion endRot = wayPoint.transform.rotation;
            float rotationPercent = 0f;
            while (rotationPercent < 1)
            {
                rotationPercent += Time.deltaTime * speed;
                transform.rotation = Quaternion.Lerp(startRot, endRot, 1);
            }*/

            transform.LookAt(endPos);
            float travelPercent = 0f;
            while (travelPercent < 1)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }
}
