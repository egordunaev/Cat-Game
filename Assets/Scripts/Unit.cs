using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс описания воздействия на персонажа.
/// </summary>
public class Unit : MonoBehaviour
{
    /// <summary>
    /// Метод описания урона для персонажа.
    /// </summary>
    public virtual void ReceiveDamage()
    {
        Die();

    }
    /// <summary>
    /// Метод описания смерти для персонажа.
    /// </summary>
    protected virtual void Die()
    {
        Destroy(gameObject);
    }

}
