using System;
using System.Collections;
using UnityEngine;

public class TowerFire : MonoBehaviour
{
    // Start is called before the first frame update

    public float fireRadius = 0.2f;
    public String damageType;
    public float fireSpeed = 0.5f;
    public int towerDamage = 20;
    void Start()
    {
        StartCoroutine(waitForFire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator waitForFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireSpeed);
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, fireRadius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.tag.Equals("enemy"))
                {
                    hitCollider.gameObject.GetComponent<Enemy>().TakeDamage(towerDamage, damageType);
                }
            }
        }
    }
}
