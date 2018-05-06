using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс описания пополнения жизни.
/// </summary>
public class Heart : MonoBehaviour
{
    /// <summary>
    /// Метод, описывающий пополнение количества жизни при соприкосновении коллайдера игрока с определенным элементом на карте.
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();

        if(character)
        {
            character.Lives++;
            Destroy(gameObject);
        }
    }
	
}
