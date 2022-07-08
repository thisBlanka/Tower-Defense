using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTower : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    private Collider2D towerColl;
    [SerializeField] private float cost;
    [SerializeField] private GameObject actionBar;
    private bool isDragging, canShoot;
    Animator anim;
    private CoinManager coinManager;
    private AudioSource coinSound;
    private Color red, black;

    PlaceTowerHandler placeTower;

    [SerializeField] private Collider2D canPlace1, canPlace2, canPlace3, 
        canPlace4, canPlace5, canPlace6, canPlace7, canPlace8, canPlace9, 
        canPlace10, canPlace11, canPlace12, canPlace13, canPlace14, canPlace15, 
        canPlace16, canPlace17;


    public void Start()
    {
        red = new Color(255,0,0,0.5f);
        black = new Color(0,0,0,0.5f);
        placeTower = GameObject.Find("CanPlaceTower").GetComponent<PlaceTowerHandler>();
        coinSound = GameObject.Find("Coin1").GetComponent<AudioSource>();
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        anim = actionBar.GetComponent<Animator>();
    }

    public void Update()
    {
        if (towerColl != null && (towerColl.IsTouching(canPlace1) ||
            towerColl.IsTouching(canPlace2) || towerColl.IsTouching(canPlace3) || towerColl.IsTouching(canPlace4) || towerColl.IsTouching(canPlace5) ||
            towerColl.IsTouching(canPlace6) || towerColl.IsTouching(canPlace7) || towerColl.IsTouching(canPlace8) || towerColl.IsTouching(canPlace9) ||
            towerColl.IsTouching(canPlace10) || towerColl.IsTouching(canPlace11) || towerColl.IsTouching(canPlace12) || towerColl.IsTouching(canPlace13) ||
            towerColl.IsTouching(canPlace14) || towerColl.IsTouching(canPlace15) || towerColl.IsTouching(canPlace16) || towerColl.IsTouching(canPlace17)))
        {
            towerColl.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = black;
        }
        else if(towerColl != null)
        {
            towerColl.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = red;
        }
    }

    public void OnMouseDown()
    {
        coinManager.setCurrentCost(cost);
        isDragging = true;
        canShoot = false;
        Instantiate(tower, new Vector2(100f, 0f), Quaternion.identity);
        towerColl = placeTower.getCurrentTower().GetComponent<Collider2D>();
    }

    public void OnMouseUp()
    {
        if (coinManager.getCoin() >= coinManager.getCurrentCost() && (towerColl.IsTouching(canPlace1) || 
            towerColl.IsTouching(canPlace2) || towerColl.IsTouching(canPlace3) || towerColl.IsTouching(canPlace4) || towerColl.IsTouching(canPlace5) || 
            towerColl.IsTouching(canPlace6) || towerColl.IsTouching(canPlace7) || towerColl.IsTouching(canPlace8) || towerColl.IsTouching(canPlace9) || 
            towerColl.IsTouching(canPlace10) || towerColl.IsTouching(canPlace11) || towerColl.IsTouching(canPlace12) || towerColl.IsTouching(canPlace13) || 
            towerColl.IsTouching(canPlace14) || towerColl.IsTouching(canPlace15) || towerColl.IsTouching(canPlace16) || towerColl.IsTouching(canPlace17)))
        {
            coinSound.Play();
            coinManager.setCoin(coinManager.getCoin() - coinManager.getCurrentCost());
            canShoot = true;
            isDragging = false;
        }
        else
        {
            isDragging = false;
            Destroy(towerColl.gameObject);
        }

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
