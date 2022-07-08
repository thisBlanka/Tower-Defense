using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDrag : MonoBehaviour
{
    private BuyTower drag;
    private BuyTower canShoot;
    [SerializeField] SpriteRenderer showRange;
    private PlaceTowerHandler canPlace;

    bool placed;

    private void Awake()
    {
        if (this.gameObject.name.Equals("Tower1(Clone)"))
        {
            drag = GameObject.Find("Tower1").GetComponent<BuyTower>();
        }
        else if (this.gameObject.name.Equals("Tower2(Clone)"))
        {
            drag = GameObject.Find("Tower2").GetComponent<BuyTower>();
        }
        canPlace = GameObject.Find("CanPlaceTower").GetComponent<PlaceTowerHandler>();
        placed = false;
    }

    private void Update()
    {
        if (!placed && drag.getDrag())
        {
            canPlace.setIsBuying(true);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
        else
        {
            canPlace.setIsBuying(false);
            if (!placed && showRange.tag != "RangeStatic")
            {
                showRange.enabled = false;
            }
            placed = true;
        }
    }
}
