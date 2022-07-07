using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Collider2D mainTowerColl;
    public EnemyMove move;
    public Collider2D coll;
    private float cooldown;
    private bool inRoute;
    Animator anim;
    private EnemyLife life;
    private bool inBattle;
    public GameObject target;
    TroopLife trooplife;
    private List<GameObject> targets;

    [SerializeField] float damage;
    [SerializeField] float coolDown;

    [SerializeField] private AudioSource attackSound;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        life = GetComponent<EnemyLife>();
        mainTowerColl = GameObject.Find("PlayerTower").GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        move = GetComponent<EnemyMove>();
        targets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!life.getIsDead())
        {

            if (this.coll.IsTouching(mainTowerColl))
            {
                inRoute = false;
                move.setMoveEnable(false);
                DealDamage(mainTowerColl.gameObject);
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
                    if (move.getSpeedHorizontal() > 0)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                        anim.SetTrigger("Forward");
                    }
                    else if (move.getSpeedHorizontal() < 0)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                        anim.SetTrigger("Forward");
                    }
                    else if (move.getSpeedVertical() > 0)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                        anim.SetTrigger("Up");
                    }
                    else if (move.getSpeedVertical() < 0)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
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
            if (target.CompareTag("MainTower"))
            {
                TowerLife towerLife = mainTowerColl.GetComponent<TowerLife>();
                towerLife.setTowerLife(towerLife.getTowerLife() - 1);
            }else if (target.CompareTag("Troop"))
            {
                trooplife = target.GetComponent<TroopLife>();
                trooplife.setTroopLife(trooplife.getTroopLife() - 1);
            }

            attackSound.Play();
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
                transform.localScale = new Vector3(1, 1, 1);
                anim.SetTrigger("AttackUP");
            }
            else if (move.getSpeedVertical() < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
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
        if (collision.CompareTag("Troop"))
        {
            targets.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Troop"))
        {
            targets.Remove(collision.gameObject);
        }
    }

    /*public static bool IsIntersecting(Collider2D col, string layer)
    {
        int layerInt = LayerMask.NameToLayer(layer);
        return col.IsTouchingLayers(1 << layerInt);
    }*/

}
