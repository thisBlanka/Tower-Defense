using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTroop : MonoBehaviour
{
    Collider2D area_CanInstantiate;
    Collider2D area_CanInstantiate2;
    Collider2D area_CanInstantiate3;
    Collider2D area_CanInstantiate4;
    private Collider2D coll;
    [SerializeField] GameObject troop;
    private int spawnPlace;
    private CoinManager coinManager;
    private AudioSource coinSound;
    // Start is called before the first frame update
    void Start()
    {
        coinSound = GameObject.Find("Coin1").GetComponent<AudioSource>();
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        area_CanInstantiate = GameObject.Find("CanPlaceCharacter").transform.GetChild(0).GetComponent<Collider2D>();
        area_CanInstantiate2 = GameObject.Find("CanPlaceCharacter").transform.GetChild(1).GetComponent<Collider2D>();
        area_CanInstantiate3 = GameObject.Find("CanPlaceCharacter2").transform.GetChild(0).GetComponent<Collider2D>();
        area_CanInstantiate4 = GameObject.Find("CanPlaceCharacter2").transform.GetChild(1).GetComponent<Collider2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && coll.IsTouching(area_CanInstantiate) && coinManager.getCoin() >= coinManager.getCurrentCost()|| Input.GetMouseButtonDown(0) && coll.IsTouching(area_CanInstantiate2) && coinManager.getCoin() >= coinManager.getCurrentCost() || 
            Input.GetMouseButtonDown(0) && coll.IsTouching(area_CanInstantiate3) && coinManager.getCoin() >= coinManager.getCurrentCost() || Input.GetMouseButtonDown(0) && coll.IsTouching(area_CanInstantiate4) && coinManager.getCoin() >= coinManager.getCurrentCost())
        {
            coinSound.Play();
            if(transform.position.y > 2)
            {
                spawnPlace = 1;
            }
            else if(transform.position.y < -2)
            {
                spawnPlace = 2;
            }else if(transform.position.y > 0 && transform.position.y < 2 && transform.position.x > - 13.5f)
            {
                spawnPlace = 3;
            }
            else if (transform.position.y > -2 && transform.position.y < 0 && transform.position.x > -13.5f)
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
            coinManager.setCoin(coinManager.getCoin() - coinManager.getCurrentCost());
            Instantiate(troop, transform.position, Quaternion.identity);
        }
    }

    public int getSpawnPlace()
    {
        return this.spawnPlace;
    }
}
