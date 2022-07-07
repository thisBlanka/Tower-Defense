using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLife : MonoBehaviour
{
    [SerializeField] float life;
    private float prevLife;
    private Animator anim;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        prevLife = life;
    }

    // Update is called once per frame
    void Update()
    {

        if(life < prevLife)
        {
            anim.SetTrigger("TakeHit");
            prevLife = life;
        }

        if(life <= 0 && !isDead)
        {
            isDead = true;
            anim.SetTrigger("Death");
        }

    }

    public float getTowerLife()
    {
        return this.life ;
    }

    public void setTowerLife(float life)
    {
        this.life = life;
    }

}
