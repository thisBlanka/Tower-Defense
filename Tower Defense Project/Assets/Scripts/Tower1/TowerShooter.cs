using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooter : MonoBehaviour
{
    [SerializeField] private Range inRange;
    [SerializeField] private Projectile projectile;
    [SerializeField] private GameObject shootPos;
    private Vector3 shootPosition;
    private float coolDown;
    [SerializeField] private AudioSource shootSound;
    private bool ableToShoot;
    private BuyTower canShoot;
    // Start is called before the first frame update
    void Awake()
    {
        shootPosition = shootPos.transform.position;
        coolDown = 0;
        if (this.gameObject.name.Equals("Tower1(Clone)"))
        {
            canShoot = GameObject.Find("Tower1").GetComponent<BuyTower>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot.getCanShoot())
        {
            ableToShoot = true;
        }
        if(inRange.getSize() > 0 && ableToShoot)
        {
            if(coolDown <= 0)
            {
                shootSound.Play();
                projectile.Create(transform.position, inRange.getTarget().transform.position, inRange.getTarget());
                coolDown = 1f;
            }
            else
            {
                coolDown -= Time.deltaTime;
            }
            
        }
    }
}
