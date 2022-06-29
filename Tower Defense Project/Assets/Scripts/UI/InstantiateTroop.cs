using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTroop : MonoBehaviour
{
    Collider2D area_CanInstantiate;
    private Collider2D coll;
    [SerializeField] GameObject troop;
    private int spawnPlace;
    // Start is called before the first frame update
    void Start()
    {
        area_CanInstantiate = GameObject.Find("CanPlaceCharacter").GetComponent<Collider2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && coll.IsTouching(area_CanInstantiate))
        {
            if(transform.position.y > 0)
            {
                spawnPlace = 1;
            }
            else if(transform.position.y <= 0)
            {
                spawnPlace = 2;
            }
            Instantiate(troop, transform.position, Quaternion.identity);
        }
    }

    public int getSpawnPlace()
    {
        return this.spawnPlace;
    }
}
