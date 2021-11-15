using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{

    public float damage;
    public float damageRate;
    float nextDamage;

    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0f; //also can do Time.time
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && nextDamage < Time.time)
        {
            Health thePlayerHealth = other.gameObject.GetComponent<Health>();
            thePlayerHealth.TakeDamage(damage);
            nextDamage = Time.time + damageRate;

        }

    }
}