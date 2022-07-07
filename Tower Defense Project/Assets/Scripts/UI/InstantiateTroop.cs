using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTroop : MonoBehaviour
{
    Collider2D area_CanInstantiate;
    Collider2D area_CanInstantiate2;
    private Collider2D coll;
    [SerializeField] GameObject troop;
    private int spawnPlace;
    // Start is called before the first frame update
    void Start()
    {
        area_CanInstantiate = GameObject.Find("CanPlaceCharacter").GetComponent<Collider2D>();
        area_CanInstantiate2 = GameObject.Find("CanPlaceCharacter2").GetComponent<Collider2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && coll.IsTouching(area_CanInstantiate) || Input.GetMouseButtonDown(0) && coll.IsTouching(area_CanInstantiate2))
        {
            if(transform.position.y > 2)
            {
                spawnPlace = 1;
            }
            else if(transform.position.y < -2)
            {
                spawnPlace = 2;
            }else if(transform.position.y > 0 && transform.position.y < 2 && transform.position.x > -14)
            {
                spawnPlace = 3;
            }
            else if (transform.position.y > -2 && transform.position.y < 0 && transform.position.x > -14)
            {
                spawnPlace = 4;
            }
            else if (transform.position.y > 0 && transform.position.y < 2)
            {
                spawnPlace = 5;
            }
            else if (transform.position.y < 0 && transform.position.y > -2)
            {
                spawnPlace = 6;
            }
            Instantiate(troop, transform.position, Quaternion.identity);
        }
    }

    public int getSpawnPlace()
    {
        return this.spawnPlace;
    }
}
