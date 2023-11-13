using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AirplaneController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] UnityEvent onCollide;
    [SerializeField][Min(0)] private float impulseForce = 5;
    private bool doLeap;
    private bool isDead;
    private Vector3 originalPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        originalPos = this.transform.position;
    }

    private void Update()
    {
        animator.SetFloat(Strings.velocityY, rb.velocity.y);
    }

    private void FixedUpdate()
    {
        if(doLeap) Leap();
    }

    public void Impulse(){
        doLeap = true;
    }

    private void Leap(){
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
        doLeap = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        rb.simulated = false;
        onCollide.Invoke();
        this.enabled = false;
        isDead = true;
    }

    public void Activate(){
        if(!isDead) return;
        rb.simulated = true;
        this.transform.position = originalPos;
        isDead = false;
    }
}
