using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class BossFlip : MonoBehaviour
{
    public Transform playerCharacter;
    private SpriteRenderer spriteRenderer;

    public void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        this.spriteRenderer.flipX = playerCharacter.transform.position.x < this.transform.position.x;
    }
}



