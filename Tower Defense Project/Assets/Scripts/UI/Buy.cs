using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    [SerializeField] private GameObject troop;
    [SerializeField] private float cost;
    [SerializeField] private GameObject actionBar;
    private Vector2 spawnPos;
    [SerializeField] private SpriteRenderer troopSample;
    private CanPlaceCharacter canPlace, canPlace2;
    private CoinManager coinManager;

    public void Start()
    {
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        canPlace = GameObject.Find("CanPlaceCharacter").GetComponent<CanPlaceCharacter>();
        canPlace2 = GameObject.Find("CanPlaceCharacter2").GetComponent<CanPlaceCharacter>();
        //anim = actionBar.GetComponent<Animator>();
    }
    public void SpawnTroop()
    {
        coinManager.setCurrentCost(cost);
        spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(!canPlace.getIsBuying())
            Instantiate(troopSample, spawnPos, Quaternion.identity);
        canPlace.setIsBuying(true);
        canPlace2.setIsBuying(true);
    }

}
