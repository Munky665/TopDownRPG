using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Stat damage;
    public Stat armor;

    public float health { get; protected set; }
    public float maxHealth;
    public float mana { get; protected set; }
    public float maxMana;
    public float manaRecoveryRate = 0.2f;
    public float damageTimer;
    public Image healthBar;
    public Image manaBar;
    protected Animator anim;
    protected IController controller;

    public AudioClip hurt;
    public AudioClip death;

    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
        mana = maxMana;
        controller = GetComponent<IController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(mana < maxMana)
        {
            RegenMana(manaRecoveryRate * Time.deltaTime);
        }
    }

    internal void UseMana(int manaCost)
    {
        mana -= manaCost;
        UpdateImageFill(mana, maxMana, manaBar);
    }

    public virtual void Damage(float d)
    {
        if (!GetComponent<IController>().isDead)
        {
            d -= armor.GetValue();
            d = Mathf.Clamp(d, 0, int.MaxValue);

            health -= d;
        }
        UpdateImageFill(health, maxHealth, healthBar);
    }

    public virtual void Death()
    {
        anim.SetBool("IsDead", true);
        controller.isDead = true;
    }

    public void Heal(float n)
    {
        health += n;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateImageFill(health, maxHealth, healthBar);
    }

    internal void RegenMana(float n)
    {
        mana += n;
        if (mana > maxMana)
        {
            mana = maxMana;
        }
        UpdateImageFill(mana, maxMana, manaBar);
    }

    protected void UpdateImageFill(float current, float max, Image image)
    {
        var ratio = current / max;
        image.fillAmount = ratio;
        PlayerStatManager.instance.UpdateUI();
    }
}
