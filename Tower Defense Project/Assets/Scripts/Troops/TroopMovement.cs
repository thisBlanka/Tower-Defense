using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopMovement : MonoBehaviour
{
    Animator anim;
    private float speedVertical;
    private float speedHorizontal;
    private float route_fix, spawn, fixN, troopSize, corrector;
    [SerializeField] float speed;
    public int route_case, fix_case;
    public bool moveEnable, fixing;
    private Collider2D coll;
    private bool routeFix, inRoute, specialCase1, specialCase2;
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
        route_case = 0;
        corrector = .78f;
        troopSize = 0.4375f;
        speedHorizontal = +speed;
        speedVertical = 0;
        if (spawnPlace.getSpawnPlace() == 1)
        {
            specialCase1 = false;
            specialCase2 = false;
            speedHorizontal = +speed;
            speedVertical = 0;
            spawn = transform.position.y - 3f;
        }
        else if (spawnPlace.getSpawnPlace() == 2)
        {
            specialCase1 = false;
            specialCase2 = false;
            speedHorizontal = +speed;
            speedVertical = 0;
            spawn = transform.position.y + 3f;
        }
        if (spawnPlace.getSpawnPlace() == 3)
        {
            spawn = transform.position.x + 12f;
            specialCase1 = true;
            specialCase2 = false;
            speedVertical = +speed;
            speedHorizontal = 0;
        }
        else if (spawnPlace.getSpawnPlace() == 4)
        {
            spawn = transform.position.x + 12f;
            specialCase1 = false;
            specialCase2 = true;
            speedVertical = -speed;
            speedHorizontal= 0;
        }
        if (spawnPlace.getSpawnPlace() == 5)
        {
            specialCase1 = false;
            specialCase2 = false;
            speedHorizontal = +speed;
            speedVertical = 0;
            spawn = transform.position.y - 1f;
        }
        else if (spawnPlace.getSpawnPlace() == 6)
        {
            specialCase1 = false;
            specialCase2 = false;
            speedHorizontal = +speed;
            speedVertical = 0;
            spawn = transform.position.y + 1f;
        }
        routeFix = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!life.getIsDead() && moveEnable)
        {
            if (inRoute)
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
                        fix = new Vector2(this.transform.position.x + spawn + troopSize + corrector, this.transform.position.y);
                    }
                    else if (speedHorizontal < 0)
                    {
                        fix_case = 1;
                        fix = new Vector2(this.transform.position.x + spawn - troopSize - corrector, this.transform.position.y);
                    }
                    else if (speedVertical > 0)
                    {
                        fix_case = 2;
                        fix = new Vector2(this.transform.position.x, this.transform.position.y + spawn + troopSize + corrector);
                    }
                    else if (speedVertical < 0)
                    {
                        fix_case = 3;
                        fix = new Vector2(this.transform.position.x, this.transform.position.y + spawn - troopSize - corrector);
                    }
                }

                if (!specialCase1 && !specialCase2)
                {
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
                else
                {
                    specialCase1 = false;
                    specialCase2 = false;  
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

