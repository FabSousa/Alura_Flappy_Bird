using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AirplaneController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField][Min(0)] float impulseForce = 5;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
        }
    }
}
