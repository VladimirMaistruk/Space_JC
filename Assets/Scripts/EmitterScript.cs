using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{

    public GameObject asteroid;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public GameObject enemyShip;
    public GameObject shield;
    public float minDelay, maxDelay;//задержка между запусками

    float nextLaunchTime;

   

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextLaunchTime)
        {
            
            float xSize = transform.localScale.x / 2;
            Vector3 newObjectPosition = new Vector3(
                Random.Range(-xSize, xSize),
                0,
                transform.position.z
                );
            float rand = Random.Range(1,4);
            GameObject newObject;
            if (rand == 1)
                newObject = enemyShip;
            else if (rand == 2)
                newObject = asteroid2;
            else if (rand == 3)
                newObject = asteroid3;
            else 
                newObject = asteroid;

            Instantiate(newObject, newObjectPosition, Quaternion.identity);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
