using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAreaDMG : MonoBehaviour
{
    [SerializeField] private Range inRange;
    private EnemyLife enemyLife;
    private float coolDown;
    [SerializeField] private AudioSource shootSound;
    private bool isShooting;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private BuyTower canShoot;
    private bool ableToShoot;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        anim = transform.GetChild(0).gameObject.GetComponent<Animator>();
        coolDown = 0;
        if (this.gameObject.name.Equals("Tower2(Clone)"))
        {
            canShoot = GameObject.Find("Tower2").GetComponent<BuyTower>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot.getCanShoot())
        {
            ableToShoot = true;
        }

        if (inRange.getSize() > 0 && ableToShoot)
        {
            spriteRenderer.enabled = true;
            if (coolDown <= 0)
            {
                anim.SetTrigger("Ring");
                shootSound.Play();
                foreach (GameObject enemie in inRange.getList())
                {
                    enemyLife = enemie.GetComponent<EnemyLife>();
                    enemyLife.setEnemyLife(enemyLife.getEnemyLife() - 1);
                }
                coolDown = 2f;
            }
            else
            {
                coolDown -= Time.deltaTime;
            }

        }
        else
        {
            isShooting =false;
            //shootSound.Stop();
        }

    }
}
