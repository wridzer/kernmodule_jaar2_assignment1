using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDamageble : MonoBehaviour
{
    public float Health { get; private set; }

    public virtual void TakeDamage(float _damage)
    {
        Health -= _damage;
    }
}
