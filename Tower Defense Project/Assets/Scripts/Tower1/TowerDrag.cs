using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDrag : MonoBehaviour
{
    private BuyTower drag;
    private BuyTower canShoot;
    [SerializeField] SpriteRenderer showRange;

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
        placed = false;
    }

    private void Update()
    {
        if (!placed && drag.getDrag())
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
        else
        {
            if (!placed && showRange.tag != "RangeStatic")
            {
                showRange.enabled = false;
            }
            placed = true;
        }
    }
}
