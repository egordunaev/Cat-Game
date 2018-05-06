using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, описывающий движение камеры.
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0F;

    [SerializeField]
    private Transform target;

    /// <summary>
    /// Метод вызова.
    /// </summary>
    private void Awake()
    {
        if (!target) target = FindObjectOfType<Character>().transform;
    }

    /// <summary>
    /// Метод, описывающий движение камеры в зависимости от движения персонажа.
    /// </summary>
    private void Update()
    {
        Vector3 position = target.position; position.z = -10.0F;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
	
}
