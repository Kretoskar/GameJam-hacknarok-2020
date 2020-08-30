using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    //Play Global
    private static BgMusic instance = null;
    public static BgMusic Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
    //Play Gobal End

    // Update is called once per frame
    void Update()
    {

    }
}

