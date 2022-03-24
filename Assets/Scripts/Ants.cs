using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ants : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private bool test = true;

    // Start is called before the first frame update
    void Start()
    {
        //int angle = Random.Range(0, 360);
        //transform.Rotate(Vector3.forward * angle);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col) {
        transform.Rotate(Vector3.forward * Random.Range(92, 124));
    }
}
