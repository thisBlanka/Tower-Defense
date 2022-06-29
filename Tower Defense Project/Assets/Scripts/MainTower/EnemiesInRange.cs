using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesInRange : MonoBehaviour
{
    [SerializeField] private EnemyFront inFront;
    private List<GameObject> enemies;
    private EnemyLife enemyLife;
    private float coolDown;
    private bool priority;
    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>(); 
        coolDown = 0f;
        enemies = new List<GameObject>();
    }

    private void Update()
    {
        if (this.coll.IsTouching(inFront.getInFrontColl()))
        {
            priority = true;
        }
        else
        {
            priority = false;
        }

        if (priority)
        {
            if(coolDown <= 0f)
            {
                enemyLife = getTarget().GetComponent<EnemyLife>();
                enemyLife.setEnemyLife(enemyLife.getEnemyLife() - 1);
                coolDown = 0.5f;
            }
            else
            {
                coolDown -= Time.deltaTime;
            }
        }
        else if (enemies.Count > 0)
        {
            if (coolDown <= 0f)
            {
                enemyLife = getTarget().GetComponent<EnemyLife>();
                enemyLife.setEnemyLife(enemyLife.getEnemyLife() - 3);
                coolDown = 0.5f;
            }
            else
            {
                coolDown -= Time.deltaTime;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            enemies.Add(coll.gameObject); 
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            enemies.Remove(coll.gameObject);
        }
    }

    public GameObject getTarget()
    {
        if(enemies.Count == 0 && !priority)
        {
            return null;
        }
        else if (priority)
        {
            return inFront.getInFront();
        }
        else
        {
            return enemies[0].gameObject;
        }  
    }

    public int getSize()
    {
        if (priority)
        {
            return 1;
        }
        else
        {
            return enemies.Count;
        } 
    }

}
