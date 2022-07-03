using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public EnemyFront inFront;
    public int life, prevLife, lifeCondition;

    public Material flash;
    private Material original;

    public float flashDuration;

    private Coroutine flashRoutine;

    private SpriteRenderer spriteRenderer;

    private Color color, originalColor;

    private Animator animator;

    private bool isDead;
    private Collider2D coll;

    [SerializeField]
    private GameObject bloodSplash;
    [SerializeField]
    private GameObject bloodPermanent;

    [SerializeField]
    private AudioSource bloodSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        original = spriteRenderer.material;
        life = 10;
        lifeCondition = life;
        prevLife = life;
        color = original.color;
        isDead = false;
        coll = GetComponent<Collider2D>();
        originalColor = original.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (prevLife > life)
        {
            Flash();
            color.r = color.r - .07f * (prevLife - life);
            color.g = color.g - .07f * (prevLife - life);
            color.b = color.b - .07f * (prevLife - life);
            original.color = color;
            prevLife = life;
        }
        if (life <= 0)
        {
            color = originalColor;
            original.color = color;
            if (!isDead)
            {
                Instantiate(bloodSplash, this.transform);
                Instantiate(bloodPermanent, this.transform);
                bloodSound.Play();
                isDead = true;
                coll.enabled = false;
                animator.SetTrigger("Death");
            }
        }
    }

    private IEnumerator FlashRoutine()
    {

        spriteRenderer.material = flash;

        yield return new WaitForSeconds(flashDuration);

        spriteRenderer.material = original;

        flashRoutine = null;
    }

    public void Flash()
    {

        if(flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    public int getEnemyLife()
    {
        return this.life;
    }

    public void setEnemyLife(int life)
    {
        this.life = life;
    }

    public bool getIsDead()
    {
        return isDead;
    }

}
