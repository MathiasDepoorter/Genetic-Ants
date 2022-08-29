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
}
