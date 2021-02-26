using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotumStats : Stats
{
    public override void Death()
    {
        Destroy(this.gameObject);
    }
}
