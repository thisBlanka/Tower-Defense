using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject projectiles;
    private Vector3 targetPosition;
    private EnemyLife enemyLife;
    private GameObject target;
    [SerializeField] private float fix;
    [SerializeField] private int damage;
    [SerializeField] private bool hasDeathAnimation, hasLight, hasHitSound;
    private bool dead;

    public void Create(Vector3 spawnPosition, Vector3 targetPosition, GameObject target)
    {
        Transform project = Instantiate(projectiles.transform, spawnPosition, Quaternion.identity);
        Projectile projectile = project.transform.GetComponent<Projectile>();
        projectile.setTarget(targetPosition, target);
    }

    public void setTarget(Vector3 targetPosition, GameObject target)
    {
        this.targetPosition = new Vector3(targetPosition.x, targetPosition.y, 0);
        this.target = target;
    }

    public float angleFix(Vector3 dir)
    {
        dir = dir.normalized;

        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; 

        if(n < 0)
        {
            n += 360;
        }

        return n;

    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (target.gameObject != null)
            {
                targetPosition = target.transform.position;
            }

            Vector3 moveDir = (targetPosition - transform.position).normalized;
            float speed = 4f;

            transform.position += moveDir * speed * Time.deltaTime;

            float angle = angleFix(moveDir);
            transform.eulerAngles = new Vector3(0, 0, angle - fix);

            float destroySelfDistance = 0.2f;
            if (Vector3.Distance(transform.position, targetPosition) < destroySelfDistance)
            {
                if (target.gameObject != null)
                {
                    enemyLife = target.GetComponent<EnemyLife>();
                    enemyLife.setEnemyLife(enemyLife.getEnemyLife() - damage);
                }

                if (hasLight)
                {
                    GameObject light = transform.GetChild(0).gameObject;
                    light.SetActive(false);
                }

                if (hasHitSound)
                {
                    GameObject sound = transform.GetChild(1).gameObject;
                    AudioSource soundSource = sound.GetComponent<AudioSource>();
                    soundSource.Play();
                }

                if (hasDeathAnimation)
                {
                    dead = true;
                    Animator anim = this.GetComponent<Animator>();
                    anim.SetTrigger("Death");

                }
                else
                    Destroy(this.gameObject);
            }
        }
    }
}
