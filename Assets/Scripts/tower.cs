using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class tower : MonoBehaviour
{
    private List<GameObject> _objectsInArea = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Shoot), 1f, 1f);  
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Shoot()
    {
        Debug.Log(_objectsInArea.Count);
        // inflict damage
        //_objectsInArea.ForEach(obj => Debug.Log(obj.damage()));
    }
    private void OnTriggerEnter(Collider otherCol)
    {
        GameObject other = otherCol.gameObject;
        Debug.Log(other.tag+" in "+other.CompareTag("enemy")+" "+_objectsInArea.Contains(other));
        if (other.CompareTag("enemy") && !_objectsInArea.Contains(other))
        {
            _objectsInArea.Add(other); 
        }
    }
    private void OnTriggerExit(Collider otherCol)
    {
        GameObject other = otherCol.gameObject;
        Debug.Log(other.tag + " out " + other.CompareTag("enemy"));
        if (other.CompareTag("enemy"))
        {
            _objectsInArea.Remove(other); 
        }
    }
}
