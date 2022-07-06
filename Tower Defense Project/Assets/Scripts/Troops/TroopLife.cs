using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopLife : MonoBehaviour
{

    private bool isShaking;

    [SerializeField] float shakeAmount;

    public int life, prevLife, lifeCondition;

    private Vector3 originalPos;

    public Material flash;

    private Material original;

    public float flashDuration;

    private Coroutine flashRoutine;

    private SpriteRenderer spriteRenderer;

    private Color color, originalColor;

    private Collider2D coll;

    private bool isDead;

    private Animator animator;

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
        isDead = false;
        coll = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        original = spriteRenderer.material;
        lifeCondition = life;
        prevLife = life;
        color = original.color;
        originalColor = original.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (prevLife > life)
        {
            ShakeMe();
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
                isDead = true;
                coll.enabled = false;
                animator.SetTrigger("Death");
                Instantiate(bloodSplash, this.transform);
                Instantiate(bloodPermanent, this.transform);
                bloodSound.Play();
            }
        }

        if (isShaking)
        {
            Vector3 newPos = transform.position + Random.insideUnitSphere * (Time.deltaTime * shakeAmount);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;
            transform.position = newPos;
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

        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    public void ShakeMe()
    {
        StartCoroutine("ShakeNow");
    }

    IEnumerator ShakeNow()
    {
        originalPos = transform.position;
        if (isShaking == false)
        {
            isShaking = true;
        }
        yield return new WaitForSeconds(0.1f);
        isShaking = false;
        TroopMovement move = GetComponent<TroopMovement>();
        if (move.getSpeedHorizontal() != 0)
        {
            transform.position = new Vector3(transform.position.x, originalPos.y, originalPos.z);
        }
        else
        {
            transform.position = new Vector3(originalPos.x, transform.position.y, originalPos.z);
        }
        if (!move.getMoveEnable())
        {
            transform.position = originalPos;
        }
    }

    public int getTroopLife()
    {
        return this.life;
    }

    public void setTroopLife(int life)
    {
        this.life = life;
    }

    public bool getIsDead()
    {
        return isDead;
    }

}
