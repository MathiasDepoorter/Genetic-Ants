using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ants : MonoBehaviour
{
    [SerializeField]
    private float speed;

    bool proxiFood = false;

    // Start is called before the first frame update
    void Start()
    {
        int angle = Random.Range(0, 360);
        transform.Rotate(Vector3.forward * angle);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ojectFood;

        ojectFood = searchFood();
        if (proxiFood == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, ojectFood.transform.position, Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    //Change Angle in collision and when Ants is stuck
    void OnCollisionStay2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            //Contact with food
            case "Food":
                collision.gameObject.GetComponent<Food>().quantity--;
                Debug.Log(collision.gameObject.GetComponent<Food>().quantity);
                if (collision.gameObject.GetComponent<Food>().quantity <= 0)
                {
                    Destroy(collision.gameObject);
                    proxiFood = false;
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                }
                break;
            default:
                transform.Rotate(Vector3.forward * Random.Range(60, 170));
                break;
        }
    }

    //search food in radius of 1
    GameObject searchFood()
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
