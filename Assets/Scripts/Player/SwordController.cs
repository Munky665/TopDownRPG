using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerController))]
public class SwordController : MonoBehaviour
{
    public GameObject sword;
    public GameObject swordSheath;
    public GameObject swordHand;

    private PlayerController pC;

    // Start is called before the first frame update
    void Start()
    {
        pC = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pC.IsMoving)
        {
            sword.transform.parent = swordSheath.transform;
            sword.transform.localPosition = Vector3.zero;
            sword.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
        if(pC.IsAttacking)
        {
            sword.GetComponent<CapsuleCollider>().enabled = true;
            sword.transform.parent = swordHand.transform;
            sword.transform.localPosition = Vector3.zero;
            sword.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
        else if(!pC.IsAttacking)
        {
            sword.GetComponent<CapsuleCollider>().enabled = true;
        }
    }
}
