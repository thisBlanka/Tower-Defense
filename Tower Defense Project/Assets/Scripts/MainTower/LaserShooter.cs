using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    private GameObject target;

    [SerializeField] private TroopsInRange inRange;

    private List<Laser> laserList;

    [SerializeField] private Laser laserPrefab;

    [SerializeField] private Transform point;

    private bool weaponIsOn, laserOn;

    // Start is called before the first frame update
    void Awake()
    {
        laserList = new List<Laser>();
        laserOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (inRange.getTarget() == null && laserOn)
        {
            Destroy(laserList[laserList.Count - 1].gameObject);
            laserList.RemoveAt(laserList.Count - 1);
            laserOn = false;
        }

        if (inRange.getSize() > 0)
        {
            if(target != inRange.getTarget() && laserOn)
            {
                laserOn = false;
                Destroy(laserList[laserList.Count-1].gameObject);
                laserList.RemoveAt(laserList.Count-1);
            }
            if (!laserOn)
            {
                Laser laser = Instantiate(laserPrefab);
                laser.AssignTarget(new Vector2(point.transform.position.x, point.transform.position.y), inRange.getTarget().transform);
                target = inRange.getTarget();
                laser.gameObject.SetActive(false);
                laserList.Add(laser);
                laserOn = true;
                weaponIsOn = true;
            }
            ToggleWeapon();
        }
        else
        {
            laserOn = false;
            weaponIsOn = false;
        }

    }

    private void ToggleWeapon()
    {
        if (weaponIsOn)
        {
            foreach(var laser in laserList)
            {
                laser.gameObject.SetActive(true);
            }
        }
    }

    public void setLaser(bool laserOn)
    {
        this.laserOn = laserOn;
    }

}
