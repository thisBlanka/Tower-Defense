using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private CoinManager coinManager;
    [SerializeField]
    private float coinValue;

    private bool isShaking;

    [SerializeField] float shakeAmount;

    Vector3 originalPos;

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

    private float lifePercentage, prevLifePercentage;

    [SerializeField]
    private GameObject bloodSplash;
    [SerializeField]
    private GameObject bloodPermanent;

    [SerializeField]
    private AudioSource bloodSound;

    // Start is called before the first frame update
    void Start()
    {
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        lifePercentage = 100;
        prevLifePercentage = 100;
        originalPos = transform.position;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        original = spriteRenderer.material;
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
            lifePercentage = (lifePercentage * life) / prevLife;
            ShakeMe();
            Flash();
            color.r = color.r - 0.07f * (prevLifePercentage - lifePercentage)/ 10;
            color.g = color.g - 0.07f * (prevLifePercentage - lifePercentage)/ 10;
            color.b = color.b - 0.07f * (prevLifePercentage - lifePercentage)/ 10;
            original.color = color;
            prevLife = life;
            prevLifePercentage = lifePercentage;
        }
        if (life <= 0)
        {
            color = originalColor;
            original.color = color;
            if (!isDead)
            {
                coinManager.setCoin(coinManager.getCoin() + coinValue);
                Instantiate(bloodSplash, this.transform);
                Instantiate(bloodPermanent, this.transform);
                bloodSound.Play();
                isDead = true;
                coll.enabled = false;
                animator.SetTrigger("Death");
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

        if(flashRoutine != null)
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
        EnemyMove move = GetComponent<EnemyMove>();
        if(move.getSpeedHorizontal() != 0)
        {
            transform.position = new Vector3(transform.position.x, originalPos.y, originalPos.z);
        }
        else
        {
            transform.position = new Vector3(originalPos.x, transform.position.y, originalPos.z);
        }
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
