using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> platforms=new List<GameObject>();
    public float spawnerTime;
    private float countTime;
    private Vector3 spawnerPosition;
    // Update is called once per frame
    void Update()
    {
        Spawnplatform();
    }
    public void Spawnplatform()
    {
        countTime += Time.deltaTime;
        spawnerPosition = transform.position;
        spawnerPosition.x = Random.Range(-9f, 9f);

        if (countTime >= spawnerTime)
        {
            CreatePlatform();

            countTime = 0;
        }
    }

    public void CreatePlatform()
    {
        int index = Random.Range(0,platforms.Count);
        int spikeball_num = 0;
        if (index == 4)
        {
            spikeball_num++;
        }
        if (spikeball_num > 1)
        {
            spikeball_num--;
            countTime = spawnerTime;
            return;
        }
        
        GameObject newPlatform= Instantiate(platforms[index], spawnerPosition, Quaternion.identity);
        newPlatform.transform.SetParent(this.gameObject.transform);
    }

}