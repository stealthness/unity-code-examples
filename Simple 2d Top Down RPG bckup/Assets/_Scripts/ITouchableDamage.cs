using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ITouchableDamage
{
    public void OnDamageIfTouched(Health health, int amount);
}


