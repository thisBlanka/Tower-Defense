using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    //public EnemyFront inFront;
    public TroopMovement move;
    public Collider2D coll;
    private float cooldown;
    [SerializeField] float cooldownTime;
    private bool inRoute;
    Animator anim;
    private List<GameObject> targets;
    private TroopLife life;
    private Collider2D mainTower;
    [SerializeField] private AudioSource arrow;

    [SerializeField] private Projectile projectile;
    [SerializeField] private GameObject shootPos;

    // Start is called before the first frame update
    void Start()
    {
        mainTower = GameObject.FindGameObjectWithTag("EnemyTower").GetComponent<Collider2D>();
        life = GetComponent<TroopLife>();
        targets = new List<GameObject>();
        anim = GetComponent<Animator>();
        move = GetComponent<TroopMovement>();
        cooldown = 0;
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
                inRoute = false; ;
                move.setMoveEnable(false);
                DealDamage(targets[0].gameObject);
            }
            else
            {
                move.setMoveEnable(true);
                if (!inRoute)
                {
                    inRoute = true;
                    if (move.route_case == 0)
                    {
                        anim.SetTrigger("Forward");
                    }
                    else if (move.route_case == 1)
                    {
                        anim.SetTrigger("BackWards");
                    }
                    else if (move.route_case == 2)
                    {
                        anim.SetTrigger("Up");
                    }
                    else if (move.route_case == 3)
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
            arrow.Play();
            projectile.Create(transform.position, target.transform.position, target);
            cooldown = 2f;
            cooldown = cooldownTime;

            if (move.route_case == 0)
            {
                anim.SetTrigger("AttackForward");
            }
            else if (move.route_case == 1)
            {
                anim.SetTrigger("AttackBackwards");
            }
            else if (move.route_case == 2)
            {
                anim.SetTrigger("AttackUp");
            }
            else if (move.route_case == 3)
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
        if (collision.CompareTag("Enemy"))
        {
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
}
