using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int Health { get; set; }
    public float Speed = 100;
    public List<GameObject> WaypointList;
    private Rigidbody Body;

    private GameObject NextPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<Rigidbody>();
        NextPoint = WaypointList.First();
    }

    // Update is called once per frame
    void Update()
    {
        findAndMoveToWaypoint();
    }
    
    void findAndMoveToWaypoint()
    {
        if (WaypointList.Any())
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPoint.transform.position, Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.Equals(WaypointList.First()))
        {
            if (WaypointList.Any())
            {
                WaypointList.Remove(WaypointList.First());
                NextPoint = WaypointList.First();
            }
        }
    }
}
