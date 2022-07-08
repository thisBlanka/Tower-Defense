using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAwake : MonoBehaviour
{
    private PlaceTowerHandler placeTower;
    // Start is called before the first frame update
    void Awake()
    {
        placeTower = GameObject.Find("CanPlaceTower").GetComponent<PlaceTowerHandler>();
        placeTower.setCurrentTower(this.gameObject);
    }

}
