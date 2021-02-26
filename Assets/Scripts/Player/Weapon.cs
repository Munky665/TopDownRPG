using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //public Stats weaponHolder;
    //public string targetTag;
    //bool canDamage = true;
    //private GameObject parent;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (canDamage && other.gameObject.tag == targetTag)
    //    {
    //        if (targetTag == "HitBox")
    //        {
    //            parent = other.gameObject.GetComponent<GetParentScript>().parent;
    //            parent.GetComponent<Stats>().Damage(weaponHolder.damage.GetValue());
    //            print(other.gameObject.tag + " health -" + weaponHolder.damage.GetValue() + " Trigger");
    //        }
    //        else
    //        {
    //            other.gameObject.GetComponent<Stats>().Damage(weaponHolder.damage.GetValue());
    //            print(other.gameObject.tag + " health -" + weaponHolder.damage.GetValue() + " Trigger");
    //        }
    //        canDamage = false;
    //    }

    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if(!canDamage && other.gameObject.tag == targetTag)
    //    {
    //        canDamage = true;
    //    }
    //}

}
