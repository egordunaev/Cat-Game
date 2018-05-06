using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс описания стрельбы.
/// </summary>
public class Bullet : MonoBehaviour
{
    private GameObject parent;
    public GameObject Parent { set { parent = value; } }

    private float speed = 10.0F;

    private SpriteRenderer sprite;

    private Vector3 direction;

    public Vector3 Direction { set { direction = value; } }

    /// <summary>
    /// Метод вызова графического представления снаряда.
    /// </summary>
    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    /// <summary>
    /// Метод самоуничтожения пули спустя 1.4 секунды после выпуска.
    /// </summary>
    private void Start()
    {
        Destroy(gameObject, 1.4F);
    }
    /// <summary>
    /// Метод, описывающий направление выстрела.
    /// </summary>
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
    
    /// <summary>
    /// Метод, описывающий уничтожение врага при соприкосновении коллайдера пули и врага.
    /// </summary>
    /// <param name="collider"></param>
	private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if(unit && unit.gameObject != parent)
        {
            Destroy(gameObject);
        }
    }
	
}
