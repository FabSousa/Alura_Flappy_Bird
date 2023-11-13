using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoop : MonoBehaviour
{
    [SerializeField] private SharedFloat speed;
    private Vector3 startPosition;
    private float imageSize;

    private void Start()
    {
        startPosition = transform.position;
        float originalImageSize =  GetComponent<SpriteRenderer>().size.x;
        float imageScale = transform.localScale.x;
        imageSize = originalImageSize * imageScale;
    }

    private void Update()
    {
        float movment = Mathf.Repeat(speed.value * Time.time, imageSize/2);
        transform.position = startPosition + Vector3.left * movment;
    }
}
