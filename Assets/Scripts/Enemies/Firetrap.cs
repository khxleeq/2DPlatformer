
using System.Collections;
using UnityEngine;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Firetrap Timers")]

    [SerializeField]private float activationDelay;
    [SerializeField] private float activeTime;

    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered; // when the trap is triggered
    private bool active; // when the trap is active and hurt player


    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(!triggered)
            {
                StartCoroutine(ActivateFireTrap());
            }
            if (active)
                collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private IEnumerator ActivateFireTrap()
    {  
        triggered = true;
        spriteRend.color = Color.red; //turn the sprite red to notify the player

        // Wait for delay, activate trap, turn on animation, return color back to normal
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white; //turn the sprite back to normal color
        active = true;
        anim.SetBool("activated", true);

        // Wait until x seconds, deactivate trap, reset all varaibles and animatorrr
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);


    }

}
