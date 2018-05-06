using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, описания монстра.
/// </summary>
public class Monster : Unit
{
    /// <summary>
    /// Метод получения урона монстром.
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();

        if(bullet)
        {
            ReceiveDamage();
        }
        
    }
	

}
