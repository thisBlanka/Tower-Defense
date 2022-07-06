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
        auxiliarTime = Time.time;
        auxiliarTime2 = Time.time;
        cooldown = 10;
        cdr = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cooldown += Time.deltaTime;
        if(cooldown > 10)
        {
            spawnTime += Time.deltaTime;
            if (spawnTime > auxiliarTime)
            {
                if(spawnPlace == 1) //2.78 - 1.22
                    Instantiate(enemy, new Vector2(spawnTransform.position.x, spawnTransform.position.y - Random.Range(-.78f, .78f)), Quaternion.identity);
                else if (spawnPlace == 2)
                    Instantiate(enemy, new Vector2(spawnTransform2.position.x, spawnTransform2.position.y - Random.Range(-.78f, .78f)), Quaternion.identity);
                auxiliarTime = spawnTime + .2f;
            }

            if (spawnTime > auxiliarTime2)
            {
                if (spawnPlace == 1) //2.78 - 1.22
                    Instantiate(monster1, new Vector2(spawnTransform.position.x, spawnTransform.position.y - Random.Range(-.78f, .78f)), Quaternion.identity);
                else if (spawnPlace == 2)
                    Instantiate(monster1, new Vector2(spawnTransform2.position.x, spawnTransform2.position.y - Random.Range(-.78f, .78f)), Quaternion.identity);
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
                cdr += 0.1f;
                cooldown = cdr;
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