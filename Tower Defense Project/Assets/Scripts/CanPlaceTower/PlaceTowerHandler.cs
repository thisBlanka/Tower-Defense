using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTowerHandler : MonoBehaviour
{
    public GameObject currentTower;
    private bool isBuying;

    private void Start()
    {
        currentTower = null;
    }

    public void setCurrentTower(GameObject currentTower)
    {
        this.currentTower = currentTower;
    }

    public GameObject getCurrentTower()
    {
        return this.currentTower;
    }

    public void setIsBuying(bool isBuying)
    {
        this.isBuying  = isBuying;
    }

    public bool getIsBuying()
    {
        return this.isBuying;
    }

}
