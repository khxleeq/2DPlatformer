using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBossFollow : MonoBehaviour
{
    public float moveSpeed;
    public float boundary;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    public Transform player;

    public float enemySpeed;

   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;


    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance < boundary && distance > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else if (distance <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed * Time.deltaTime);

            nextFireTime = Time.time + fireRate;
        }
      
    }

   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, boundary);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }


   
   

    }
