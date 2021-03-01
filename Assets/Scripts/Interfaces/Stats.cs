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
    }

    public virtual void Damage(float d)
    {
        d -= armor.GetValue();
        d = Mathf.Clamp(d, 0, int.MaxValue);

        health -= d;

        var ratio =  health / maxHealth;
        healthBar.fillAmount = ratio;

        if (health <= 0)
        {
            Death();
        }
        PlayerStatManager.instance.UpdateUI();
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
        var ratio = health / maxHealth;
        healthBar.fillAmount = ratio;
        PlayerStatManager.instance.UpdateUI();
    }

    internal void RegenMana(float n)
    {
        mana += n;
        if (mana > maxMana)
        {
            mana = maxMana;
        }
        
        var ratio = mana / maxMana;
        manaBar.fillAmount = ratio;
        PlayerStatManager.instance.UpdateUI();
    }
}
