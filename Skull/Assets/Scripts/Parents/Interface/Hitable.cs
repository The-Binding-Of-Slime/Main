using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Hitable
{
    public float TakeDamage(float damage);
    public float TakeHeal(float heal);
}
