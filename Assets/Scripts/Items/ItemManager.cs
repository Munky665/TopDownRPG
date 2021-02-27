using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    public GameObject healthPotion;
    public GameObject manaPotion;

    public GameObject item;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    //checks for specific number in a range of numbers then spawns a potion at the position stated with transform
    public void SpawnPotion(int odds, int numberInOdds, Transform pos)
    {
        float outcome = Random.Range(1, odds);
        print("Checking if object should spawn " + outcome);
       
        if(outcome == numberInOdds)
        {
            float potion = Random.Range(1, odds * 2);
            
            if(potion < odds)
            {
                _ = Instantiate(healthPotion, pos.position, Quaternion.identity);
                print("Spawning Health potion" + outcome.ToString());
            }
            else if(potion > odds)
            {
                _ = Instantiate(manaPotion, pos.position, Quaternion.identity);
                print("Spawning mana potion" + outcome.ToString());
            }

        }
    }

    public void SpawnEquipment(int odds, int numberInOdds, Transform pos)
    {
        float outcome = Random.Range(1, odds);

        if (outcome == numberInOdds)
        {
            float potion = Random.Range(1, odds * 2);

            if (potion < odds)
            {
                _ = Instantiate(healthPotion, pos.position, Quaternion.identity);
            }
            else if (potion > odds)
            {
                _ = Instantiate(healthPotion, pos.position, Quaternion.identity);
            }

        }
    }
}
