using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AirplaneController : MonoBehaviour
{
    Rigidbody2D rb;
    GameMode gm;
    [SerializeField][Min(0)] float impulseForce = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindObjectOfType<GameMode>() as GameMode;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        rb.simulated = false;
        gm.GameOver();
        this.enabled = false;
    }
}
