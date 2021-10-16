using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cleanPlatform;
    public GameObject infectedPlatform;

    private int platformDelayCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(platformDelayCounter == 3600)
        {
            InstantiatePlatform();
            platformDelayCounter = 0;
        }

        platformDelayCounter++;
    }

    private void InstantiatePlatform()
    {
        int platformType = Random.Range(0, 2);

        if(platformType == 0)
            Instantiate(cleanPlatform, new Vector3(15, Random.Range(0, 4), 0), Quaternion.identity);
        else
            Instantiate(infectedPlatform, new Vector3(15, Random.Range(0, 4), 0), Quaternion.identity);
    }
}
