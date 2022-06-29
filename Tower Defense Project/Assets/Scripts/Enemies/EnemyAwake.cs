using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwake : MonoBehaviour
{
    public EnemyFront front;

    private void Awake()
    {
        front.queueEnemy(this.gameObject);
    }
}
