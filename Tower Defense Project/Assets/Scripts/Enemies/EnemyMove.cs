using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMove : MonoBehaviour
{
    Animator anim;
    private Vector2 fix;
    private float speedVertical;
    private float speedHorizontal;
    private float spawn, fix_case, troopSize;
    public float speed;
    public int route_case;
    public bool moveEnable;
    [SerializeField] private Collider2D coll;
    private bool routeFix, fixing;
    private EnemyLife life;
    private EnemySpawn spawnPlace;
    // Start is called before the first frame update
    void Start()
    {
        spawnPlace = GameObject.Find("Enemies").GetComponent<EnemySpawn>();
        if(spawnPlace.getSpawnPlace() == 1)
        {
            spawn = transform.position.y - 2f;
        }else if (spawnPlace.getSpawnPlace() == 2)
        {
            spawn = transform.position.y + 2f;
        }
        life = GetComponent<EnemyLife>();
        moveEnable = true;
        troopSize = 0.4375f;
        routeFix = false;
        fixing = false;
        route_case = 1;
        fix_case = 0;
        speed = 1f;
        anim = GetComponent<Animator>();
        speedHorizontal = -speed;
        speedVertical = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!life.getIsDead())
        {
            if (moveEnable)
            {
                this.transform.position = new Vector2(this.transform.position.x + speedHorizontal * Time.deltaTime, this.transform.position.y + speedVertical * Time.deltaTime);
            }

            if (routeFix)
            {
                if (!fixing)
                {
                    fixing = true;
                    if (speedHorizontal == +speed)
                    {
                        fix_case = 0;
                        fix = new Vector2(this.transform.position.x + spawn + troopSize + .78f, this.transform.position.y);
                    }
                    else if (speedHorizontal == -speed)
                    {
                        fix_case = 1;
                        fix = new Vector2(this.transform.position.x + spawn - troopSize - .78f, this.transform.position.y);
                    }
                    else if (speedVertical == +speed)
                    {
                        fix_case = 2;
                        fix = new Vector2(this.transform.position.x, this.transform.position.y + spawn + troopSize + .78f);
                    }
                    else if (speedVertical == -speed)
                    {
                        fix_case = 3;
                        fix = new Vector2(this.transform.position.x, this.transform.position.y + spawn - troopSize - .78f);
                    }
                }

                if (fix_case == 0 && this.transform.position.x >= fix.x || fix_case == 1 && this.transform.position.x <= fix.x || fix_case == 2 && this.transform.position.y >= fix.y || fix_case == 3 && this.transform.position.y <= fix.y)
                {
                    routeFix = false;
                    fixing = false;

                    if (route_case == 0)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                        anim.SetTrigger("Forward");
                        speedHorizontal = speed;
                        speedVertical = 0;
                    }
                    else if (route_case == 1)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                        anim.SetTrigger("Forward");
                        speedHorizontal = -speed;
                        speedVertical = 0;
                    }
                    else if (route_case == 2)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                        anim.SetTrigger("Up");
                        speedHorizontal = 0;
                        speedVertical = +speed;
                    }
                    else if (route_case == 3)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                        anim.SetTrigger("Down");
                        speedHorizontal = 0;
                        speedVertical = -speed;
                    }
                    this.transform.position = fix;
                }
            }
        }
    }

    public bool getMoveEnable()
    {
        return this.moveEnable;
    }

    public float getSpeedHorizontal()
    {
        return this.speedHorizontal;
    }

    public float getSpeedVertical()
    {
        return this.speedVertical;
    }

    public void setSpeedHorizontal(float speedHorizontal)
    {
        this.speed = Mathf.Abs(speedHorizontal);
        this.speedHorizontal = speedHorizontal;
    }

    public void setSpeedVertical(float speedVertical)
    {
        this.speed = Mathf.Abs(speedVertical);
        this.speedVertical = speedVertical;
    }

    public void setMoveEnable(bool moveEnable)
    {
        this.moveEnable = moveEnable;
    }

    public void setSpawn(int spawn)
    {
        this.spawn = (this.spawn * spawn);
    }

    public void setRouteCase(int route_case)
    {
        this.route_case = route_case;
    }

    public void setRouteFix(bool routeFix)
    {
        this.routeFix = routeFix;
    }

}
