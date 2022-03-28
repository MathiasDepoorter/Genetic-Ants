using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ants : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        int angle = Random.Range(0, 360);
        transform.Rotate(Vector3.forward * angle);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        
    }

    //Change Angle in collision
    void OnCollisionEnter2D(Collision2D col) {
        //transform.Rotate(Vector3.forward * Random.Range(92, 124));
    }

    //Change Angle in collision and when Ants is stuck
    void OnCollisionStay2D(Collision2D collision)
    {
        transform.Rotate(Vector3.forward * Random.Range(60, 170));
    }
}
