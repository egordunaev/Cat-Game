using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, описывающий статичного врага, наносящего урон.
/// </summary>
public class Obstacle : MonoBehaviour
{
    /// <summary>
    /// Проверка на наличие компонента.
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if(unit && unit is Character)
        {
            unit.ReceiveDamage();
        }
    }

}
