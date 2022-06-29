using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    [SerializeField] private GameObject troop;
    [SerializeField] private int cost;
    [SerializeField] private GameObject actionBar;
    private Vector2 spawnPos;
    [SerializeField] private SpriteRenderer troopSample;
    private CanPlaceCharacter canPlace;

    public void Start()
    {
        canPlace = GameObject.Find("CanPlaceCharacter").GetComponent<CanPlaceCharacter>();
        //anim = actionBar.GetComponent<Animator>();
    }
    public void SpawnTroop()
    {
        spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(!canPlace.getIsBuying())
            Instantiate(troopSample, spawnPos, Quaternion.identity);
        canPlace.setIsBuying(true);
    }

}