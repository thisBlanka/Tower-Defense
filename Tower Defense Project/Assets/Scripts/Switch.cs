using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private int spawnFixEnemy;
    [SerializeField] private int route_caseEnemy;

    [SerializeField] private int spawnFixTroop;
    [SerializeField] private int route_caseTroop;

    private EnemyMove enemyMove;
    private TroopMovement troopMove;

    public void OnTriggerEnter2D(Collider2D coll)
    {

        if(coll.tag == "Enemy")
        {
            enemyMove = coll.GetComponent<EnemyMove>();
            enemyMove.setSpawn(spawnFixEnemy);
            enemyMove.setRouteCase(route_caseEnemy);
            enemyMove.setRouteFix(true);
        }
        else if(coll.tag == "Troop")
        {
            troopMove = coll.GetComponent<TroopMovement>();
            troopMove.setSpawn(spawnFixTroop);
            troopMove.setRouteCase(route_caseTroop);
            troopMove.setRouteFix(true);
        }
        
    }


}
