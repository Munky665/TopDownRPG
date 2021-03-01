using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatManager : MonoBehaviour
{
    public static PlayerStatManager instance;

    public List<Text> stats;
    public PlayerStats playerStats;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        stats[0].text = playerStats.level.ToString();
        stats[1].text = playerStats.health.ToString() + "/" + playerStats.maxHealth.ToString();
        stats[2].text = playerStats.mana.ToString() + "/" + playerStats.maxMana.ToString();
        stats[3].text = playerStats.damage.GetValue().ToString();
        stats[4].text = playerStats.armor.GetValue().ToString();
    }
}
