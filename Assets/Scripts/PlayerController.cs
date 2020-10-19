using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// переменная для RB игрока
    /// </summary>
    private Rigidbody rb;

    /// <summary>
    /// скорость
    /// </summary>
    private int speed = 3;

    public int Speed { set { this.speed = value; } }

    /// <summary>
    /// переменная события финиша (event)
    /// </summary>
    public event Action onFinish;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// передвижение
    /// </summary>
    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = (-movement * speed);
    }

    /// <summary>
    /// проверка тригера
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            ///вызов события финиша и проверка
            onFinish?.Invoke();
        }
    }
}
