using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [Header("FireBall Attack")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    [Header("Light Sword Attack")]
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private float lightAttackDmg = 2f;

    [Header("Sword Attack")]
    [SerializeField] private float attackDmg = 3f;


    [SerializeField] private LayerMask enemyLayers;
   

    private Animator anim;
    private PlayerMovement playerMovement;
    private Projectile projectile;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        projectile = GetComponent<Projectile>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();
        if (Input.GetMouseButton(1) && playerMovement.canAttack())
            LightSwordAttack();
        if (Input.GetKey(KeyCode.Z) && playerMovement.canAttack())
            AttackSword();
        cooldownTimer += Time.deltaTime;

        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fireRatePowerup")
        {
            Destroy(collision.gameObject);
            attackCooldown = 0.25f;
            GetComponent<SpriteRenderer>().color = Color.yellow;
            StartCoroutine(ResetPowerUp());
        }

       
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private void AttackSword()
    {
        anim.SetTrigger("attacksword");
        

       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(firePoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(attackDmg);
        }

    }
    private void LightSwordAttack()
    {
        anim.SetTrigger("lightswordattack");


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(firePoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(lightAttackDmg);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (firePoint == null)
            return;
        Gizmos.DrawWireSphere(firePoint.position, attackRange);
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    private IEnumerator ResetPowerUp()
    {
        yield return new WaitForSeconds(5);
        attackCooldown = 1f;
        GetComponent<SpriteRenderer>().color = Color.white;

    }
    

}

