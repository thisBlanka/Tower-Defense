using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopMovement : MonoBehaviour
{
    Animator anim;
    private float speedVertical;
    private float speedHorizontal;
    private float route_fix, spawn, fixN, troopSize;
    [SerializeField] float speed;
    public int route_case, fix_case;
    public bool moveEnable, fixing;
    private Collider2D coll;
    private bool routeFix, inRoute;
    Vector2 fix;
    private TroopLife life;
    private InstantiateTroop spawnPlace;
    // Start is called before the first frame update
    void Start()
    {
        life = GetComponent<TroopLife>();
        coll = GetComponent<Collider2D>();
        fix_case = 0;
        moveEnable = true;
        inRoute = true;
        spawnPlace = FindObjectOfType<InstantiateTroop>();
        if (spawnPlace.getSpawnPlace() == 1)
        {
            spawn = transform.position.y - 2f;
        }
        else if (spawnPlace.getSpawnPlace() == 2)
        {
            spawn = transform.position.y + 2f;
        }
        troopSize = 0.4375f;
        routeFix = false;
        route_case = 0;
        anim = GetComponent<Animator>();
        speedHorizontal = +speed;
        speedVertical = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!life.getIsDead())
        {
            if (moveEnable && inRoute)
            {
                this.transform.position = new Vector2(this.transform.position.x + speedHorizontal * Time.deltaTime, this.transform.position.y + speedVertical * Time.deltaTime);
            }

            if (routeFix)
            {
                if (!fixing)
                {
                    fixing = true;
                    if (speedHorizontal > 0)
                    {
                        fix_case = 0;
                        fix = new Vector2(this.transform.position.x + spawn + troopSize + .78f, this.transform.position.y);
                    }
                    else if (speedHorizontal < 0)
                    {
                        fix_case = 1;
                        fix = new Vector2(this.transform.position.x + spawn - troopSize - .78f, this.transform.position.y);
                    }
                    else if (speedVertical > 0)
                    {
                        fix_case = 2;
                        fix = new Vector2(this.transform.position.x, this.transform.position.y + spawn + troopSize + .78f);
                    }
                    else if (speedVertical < 0)
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
                        transform.localScale = new Vector3(-1,1,1);
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


    public void setMoveEnable(bool moveEnable)
    {
        this.moveEnable = moveEnable;
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

