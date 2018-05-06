using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс описания полосы здоровья.
/// </summary>
public class LivesBar : MonoBehaviour
{
    private Transform[] hearts = new Transform[5];

    private Character character;
    /// <summary>
    /// Метод описания жизней.
    /// </summary>
    private void Awake()
    {
        character = FindObjectOfType<Character>();
        for(int i=0; i<hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }
    /// <summary>
    /// Метод, описывающий количество выводимых на панель жизней.
    /// </summary>
    public void Refresh()
    {
        for(int i=0; i<hearts.Length; i++)
        {
            if (i < character.Lives) hearts[i].gameObject.SetActive(true);
            else hearts[i].gameObject.SetActive(false);
        }
    }

}

