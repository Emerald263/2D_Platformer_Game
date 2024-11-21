using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parkour : MonoBehaviour
{

    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {

        int number = 0;

        while (number < 20)
        {
            //do something
            Debug.Log(number);
            number++;

        }

        for (int i = 0; i < 5; i++)
        {
            //do something
            Debug.Log (i);
            Instantiate(platform, new Vector2(Random.Range(-7f, 7f), Random.Range(-3f, 3f)), Quaternion.identity);
        }
    }

        // Update is called once per frame
        void Update()
        {

        }
    }
