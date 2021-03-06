using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopAttack : MonoBehaviour
{
    public TroopMovement move;
    private Collider2D coll;
    private float cooldown;
    private bool inRoute;
    Animator anim;
    bool inBattle;
    public GameObject target;
    private EnemyLife enemylife;
    private TowerLife towerLife;
    private List<GameObject> targets;
    private TroopLife life;
    [SerializeField] private AudioSource stab;
    private Collider2D mainTower;

    [SerializeField] float damage;
    [SerializeField] float coolDown;

    // Start is called before the first frame update
    void Start()
    {
        mainTower = GameObject.FindGameObjectWithTag("EnemyTower").GetComponent<Collider2D>();
        life = GetComponent<TroopLife>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        move = GetComponent<TroopMovement>();
        targets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!life.getIsDead())
        {
            if (this.coll.IsTouching(mainTower))
            {
                inRoute = false;
                move.setMoveEnable(false);
                DealDamage(mainTower.gameObject);
            }
            else if (targets.Count > 0)
            {
                inRoute = false;
                move.setMoveEnable(false);
                DealDamage(targets[0].gameObject);
            }
            else
            {
                cooldown = .5f;
                move.setMoveEnable(true);
                if (!inRoute)
                {
                    inRoute = true;
                    transform.localScale = new Vector3(1, 1, 1);
                    if (move.getSpeedHorizontal() > 0)
                    {
                        anim.SetTrigger("Forward");
                    }
                    else if (move.getSpeedHorizontal() < 0)
                    {
                        anim.SetTrigger("BackWards");
                    }
                    else if (move.getSpeedVertical() > 0)
                    {
                        anim.SetTrigger("Up");
                    }
                    else if (move.getSpeedVertical() < 0)
                    {
                        anim.SetTrigger("Down");
                    }
                }
            }
        }
    }

    private void DealDamage(GameObject target)
    {
        if (cooldown <= 0)
        {
            stab.Play();
            if (target.CompareTag("Enemy")) {
                enemylife = target.GetComponent<EnemyLife>();
                enemylife.setEnemyLife(enemylife.getEnemyLife() - 1);
            }else if (target.CompareTag("EnemyTower"))
            {
                towerLife = target.GetComponent<TowerLife>();
                towerLife.setTowerLife(towerLife.getTowerLife() - 1);
            }

            cooldown = 0.5f;

            if (move.getSpeedHorizontal() > 0)
            {
                anim.SetTrigger("AttackForward");
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (move.getSpeedHorizontal() < 0)
            {
                anim.SetTrigger("AttackForward");
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (move.getSpeedVertical() > 0)
            {
                anim.SetTrigger("AttackUp");
            }
            else if (move.getSpeedVertical() < 0)
            {
                anim.SetTrigger("AttackDown");
            }
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")){
            targets.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            targets.Remove(collision.gameObject);
        }
    }

/*    public static bool IsIntersecting(Collider2D col, string layer)
    {
        int layerInt = LayerMask.NameToLayer(layer);
        return col.IsTouchingLayers(1 << layerInt);
    }*/

}
