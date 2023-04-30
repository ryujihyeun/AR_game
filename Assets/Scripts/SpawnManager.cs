using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int totalNum = 0;
    public GameObject character;
    public GameObject spawnPosition;
    public bool isSpawn = true;
    public float spawnDelay = 1.5f;
    float spawnTimer = 0.0f;
    public int characterNum = 40;
    public int spawnNum = 0;

    SystemManager systemManager = null;
    PlaceOnPlane placeOnPlane = null;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tmp = GameObject.Find("SystemManager");
        systemManager = tmp.GetComponent<SystemManager>();

        GameObject smObj = GameObject.Find("AR Session Origin");
        placeOnPlane = smObj.GetComponent<PlaceOnPlane>();
    }

    // Update is called once per frame
    void Update()
    {
        if (totalNum < characterNum)
        {
            if (spawnNum < 5)
                Spawn();
        }

    }

    public void Spawn()
    {
        if (isSpawn == true)
        {
            if (spawnTimer > spawnDelay)
            {
                Instantiate(character, spawnPosition.transform.position, spawnPosition.transform.rotation);
                --characterNum;
                spawnTimer = 0.0f;

                // update UI
                totalNum += 1;
                spawnNum += 1;
                systemManager.numOut += 1;
                systemManager.totalOut += 1;
            }

            spawnTimer += Time.deltaTime;
        }
    }
}
