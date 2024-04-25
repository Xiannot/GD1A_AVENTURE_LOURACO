using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiHeal : MonoBehaviour
{

    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarEnnemi HealthBarEnnemi;
    private Animator anim;


    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    public static EnnemiHeal instance;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

        if (instance != null)
        {
            return;
        }

        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        HealthBarEnnemi.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            TakeDamage(20);
            StartCoroutine(invunerability());
        }


    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBarEnnemi.SetHealth(currentHealth);
        StartCoroutine(invunerability());

        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    public void HealPlayer(int amount)
    {
        if ((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }
        HealthBarEnnemi.SetHealth(currentHealth);
    }


    private IEnumerator invunerability()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
