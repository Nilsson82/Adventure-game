using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public ItemType Type;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit " + collision.gameObject.name);
        AttackableBase attackable = collision.gameObject.GetComponent<AttackableBase>();

        if(attackable != null)
        {
            attackable.OnHit(Type);
        }
    }

}
