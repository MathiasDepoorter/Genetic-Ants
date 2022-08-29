using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ants : MonoBehaviour
{
    [SerializeField]
    private float speed;

    bool proxiFood = false;

    public float maxSpeed = 2;
    public float steerStrength = 2;
    public float wanderStrength = 0.0001f;

    Vector2 position;
    Vector2 velocity;
    Vector2 desiredDirection;

    // Start is called before the first frame update
    void Start()
    {
        //int angle = Random.Range(0, 360);
        //transform.Rotate(Vector3.forward * angle);
    }

    // Update is called once per frame
    void Update()
    {
        desiredDirection = (desiredDirection + Random.insideUnitCircle * wanderStrength).normalized;

        Vector2 desiredVelocity = desiredDirection * maxSpeed;
        Vector2 desiredSteeringForce = (desiredVelocity - velocity) * steerStrength;
        Vector2 acceleration = Vector2.ClampMagnitude(desiredSteeringForce, steerStrength) / 1;

        velocity = Vector2.ClampMagnitude(velocity + acceleration * Time.deltaTime, maxSpeed);
        position += velocity * Time.deltaTime;

        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.SetPositionAndRotation(position, Quaternion.Euler(0, 0, angle - 90));
        

        //GameObject ojectFood;

        //ojectFood = SearchFood();
        //if (proxiFood == true)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, ojectFood.transform.position, Time.deltaTime * speed);
        //}
        //else
        //{
        //    transform.Translate(Vector2.up * speed * Time.deltaTime);
        //}
    }

    //Change Angle in collision and when Ants is stuck
    //void OnCollisionStay2D(Collision2D collision)
    //{
    //    switch (collision.gameObject.tag)
    //    {
    //        //Contact with food
    //        case "Food":
    //            collision.gameObject.GetComponent<Food>().quantity--;
    //            Debug.Log(collision.gameObject.GetComponent<Food>().quantity);
    //            if (collision.gameObject.GetComponent<Food>().quantity <= 0)
    //            {
    //                Destroy(collision.gameObject);
    //                proxiFood = false;
    //                transform.Translate(Vector2.up * speed * Time.deltaTime);
    //            }
    //            break;
    //        default:
    //            transform.Rotate(Vector3.forward * Random.Range(60, 170));
    //            break;
    //    }
    //}

    //search food in radius of 1
    GameObject SearchFood()
    {
        GameObject gameObject = null;
        GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");
        foreach (var food in foods)
        {
            if (Vector3.Distance(transform.position, food.transform.position) < 2)
            {
                //Debug.Log(Vector3.Distance(transform.position, food.transform.position));
                proxiFood = true;
                gameObject =  food;
            }
        }
        return gameObject;
    }
}
