using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public class Enemy : MonoBehaviour
{

    public int Health { get; set; }
    public float Speed = 100;
    public List<GameObject> WaypointList;
    private Rigidbody Body;
    public float turnSpeed;
    public GameObject deathParticle;
    public GameObject damageParticle;
    private GameObject NextPoint;
    public ParticleSystem.MinMaxGradient damageColor;
    private Vector3 moveDirection;
    private Quaternion rotationGoal;
    private bool isDead;
    public Material deathMaterial;

    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
        Body = GetComponent<Rigidbody>();
        NextPoint = WaypointList.First();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            findAndMoveToWaypoint();
            if (Health <= 0)
            {
                Die();
            }

            if (!WaypointList.Any())
            {
                Die();
            } 
        }
    }
    
    void findAndMoveToWaypoint()
    {
        if (WaypointList.Any())
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPoint.transform.position, Speed * Time.deltaTime);
            Vector3 relativePos = NextPoint.transform.position - transform.position;
            moveDirection = (NextPoint.transform.position - transform.position).normalized;
            rotationGoal = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, turnSpeed * Time.deltaTime);
        }
    }

    private void Die()
    {
        isDead = true;
        Instantiate(deathParticle, transform.position, Quaternion.Euler(-90, 0, 0));
        for (int i = 0; i < 5; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = gameObject.transform.position;
            cube.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            cube.AddComponent<Rigidbody>();
            cube.GetComponent<Rigidbody>().mass = 0.1f;
            var randomEx = Random.Range(5, 10);
            cube.GetComponent<Rigidbody>().AddForce(cube.transform.up * randomEx);
            cube.GetComponent<Renderer>().material = 
            Destroy(cube, 2);
        }
        Destroy(gameObject);
  
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.Equals(WaypointList.First()))
        {
            if (WaypointList.Any())
            {
                WaypointList.Remove(WaypointList.First());
                NextPoint = WaypointList.First();
                TakeDamage(1);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        //uncomment this when using :)
        Health = Health - amount;
        GameObject particles = Instantiate(damageParticle, transform.position, Quaternion.Euler(-90, 0, 0));
        var ps = particles.GetComponent<ParticleSystem>().main;
        ps.startColor = new Color(damageColor.color.r, damageColor.color.g, damageColor.color.b);
    }
    
}
