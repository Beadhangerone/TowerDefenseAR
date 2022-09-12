using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Base : MonoBehaviour
{
    public int Health { get; set; }
    public int damage = 10;
    public int damageDeviation = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider otherCol)
    {
        GameObject other = otherCol.gameObject;
        if (other.CompareTag("enemy"))
        {
            int currentDamage = Random.Range(damage - damageDeviation, damage + damageDeviation);
            Health -= currentDamage;
            Debug.Log("Base under attack. HP: "+Health);
            if (Health <= 0)
            {
                foreach (GameObject o in GameObject.FindGameObjectsWithTag("spawn"))
                {
                    Destroy(o);
                }

                Destroy(gameObject);
            }
        }
    }
}