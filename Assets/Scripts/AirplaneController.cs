using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AirplaneController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameMode gm;
    private Animator animator;
    [SerializeField][Min(0)] private float impulseForce = 5;
    private bool doLeap;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindObjectOfType<GameMode>() as GameMode;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1")) doLeap = true;
        animator.SetFloat(Strings.velocityY, rb.velocity.y);
    }

    private void FixedUpdate()
    {
        if(doLeap) Leap();
    }

    private void Leap(){
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
        doLeap = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        rb.simulated = false;
        gm.GameOver();
        this.enabled = false;
    }
}
