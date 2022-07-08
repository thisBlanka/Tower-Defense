using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float spawnTime, auxiliarTime, auxiliarTime2, cooldown, cdr;
    [SerializeField] private GameObject enemy, monster1;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private Transform spawnTransform2;
    private int spawnPlace;
    // Start is called before the first frame update
    void Start()
    {
        spawnPlace = 1;
        auxiliarTime = 0;
        auxiliarTime2 = 0;
        cooldown = 0;
        cdr = 10;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if(cooldown > cdr)
        {
            spawnTime += Time.deltaTime;
            if (spawnTime > auxiliarTime)
            {
                if(spawnPlace == 1) //2.78 - 1.22
                    Instantiate(enemy, new Vector2(spawnTransform.position.x, spawnTransform.position.y - Random.Range(-.70f, .70f)), Quaternion.identity);
                else if (spawnPlace == 2)
                    Instantiate(enemy, new Vector2(spawnTransform2.position.x, spawnTransform2.position.y - Random.Range(-.70f, .70f)), Quaternion.identity);
                auxiliarTime = spawnTime + .2f;
            }

            if (spawnTime > auxiliarTime2)
            {
                if (spawnPlace == 1) //2.78 - 1.22
                    Instantiate(monster1, new Vector2(spawnTransform.position.x, spawnTransform.position.y - Random.Range(-.70f, .70f)), Quaternion.identity);
                else if (spawnPlace == 2)
                    Instantiate(monster1, new Vector2(spawnTransform2.position.x, spawnTransform2.position.y - Random.Range(-.70f, .70f)), Quaternion.identity);
                auxiliarTime2 = spawnTime + .1f;
            }

            if (spawnTime >= 1)
            {
                if (spawnPlace == 1)
                {
                    spawnPlace = 2;
                }
                else
                {
                    spawnPlace = 1;
                }
                if(cdr > 1) 
                    cdr -= 0.25f;
                cooldown = 0;
                spawnTime = 0;
                auxiliarTime = 0;
                auxiliarTime2 = 0;
            }
        }
    }

    public int getSpawnPlace()
    {
        return this.spawnPlace;
    }

}