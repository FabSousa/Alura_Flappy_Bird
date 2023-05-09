using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [SerializeField][Min(0)] private float speed = 10;
    void FixedUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
