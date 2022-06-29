using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTower : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    [SerializeField] private int cost;
    [SerializeField] private GameObject actionBar;
    private bool isDragging, canShoot;
    Animator anim;

    public void Start()
    {
        anim = actionBar.GetComponent<Animator>();
    }

    public void OnMouseDown()
    {
        isDragging = true;
        canShoot = false;
        Instantiate(tower, new Vector2(100f, 0f), Quaternion.identity);
    }

    public void OnMouseUp()
    {
        canShoot = true;
        isDragging = false;
    }

    public bool getDrag()
    {
        return isDragging;
    }

    public bool getCanShoot()
    {
        return canShoot;
    }

}
