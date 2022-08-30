using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   #region Singleton

    public static GameManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'un GameManager");
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion
    public int nbAnts = 1000;
    public bool isGenerated = false;
    public float trailDecay = 0.9985f;
    public float trailAddSpeed = 0.3f;
    public bool createFood = true;
    public bool createNid = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getNbAnts()
    {
        return this.nbAnts;
    }

    public bool getIsGenerated()
    {
        return this.isGenerated;
    }

    public float getTrailDecay()
    {
        return this.trailDecay;
    }
    public float getTrailAddSpeed()
    {
        return this.trailAddSpeed;
    }

    public bool getCreateFood()
    {
        return this.createFood;
    }
    public bool getCreateNid()
    {
        return this.createNid;
    }
}
