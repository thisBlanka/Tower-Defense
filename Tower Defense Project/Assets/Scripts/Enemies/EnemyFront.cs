using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFront : MonoBehaviour
{
    static Queue<GameObject> queueEnemies;
    static GameObject inFront;
    static Collider2D frontColl;
    static bool sampleEnemyGone;
    [SerializeField] private GameObject sampleEnemy;

    private void Start()
    {
        sampleEnemyGone = false;
        queueEnemies = new Queue<GameObject>();
        queueEnemy(sampleEnemy);
    }

    private void Update()
    {

        if (!sampleEnemyGone)
        {
            if (queueEnemies.Count > 1)
            {
                dequeueEnemy();
                sampleEnemyGone = true;
            }
        }

        if (sampleEnemyGone && queueEnemies.Count < 1)
        {
            queueEnemy(sampleEnemy);
            sampleEnemyGone = false;
            inFront = sampleEnemy;
            frontColl = sampleEnemy.GetComponent<Collider2D>();
        }

    }

    public void queueEnemy(GameObject enemy)
    {
        queueEnemies.Enqueue(enemy);
        inFront = queueEnemies.Peek();
        frontColl = inFront.GetComponent<Collider2D>();
    }

    public void dequeueEnemy()
    {
        queueEnemies.Dequeue();
        while (queueEnemies.Peek() == null)
        {
            queueEnemies.Dequeue();
        }
        inFront = queueEnemies.Peek();
        frontColl = inFront.GetComponent<Collider2D>();
    }

    public GameObject getInFront()
    {
        return inFront;
    }

    public void queueClear()
    {
        queueEnemies.Clear();
    }

    public int queueSize()
    {
        return queueEnemies.Count;
    }

    public void setInfront(GameObject atFront)
    {
        inFront = atFront;
    }

    public Collider2D getInFrontColl()
    {
        return frontColl;
    }

    public void setInfrontColl(Collider2D atFrontColl)
    {
        atFrontColl = frontColl;
    }
}