using UnityEngine;
using System.Collections;
using System;

public class Scan : MonoBehaviour
{
    /// <summary>
    /// количество лучей (умножается на 2)
    /// </summary>
    private int rays = 4;
    /// <summary>
    /// дальность луча
    /// </summary>
    private float distance = 5.1f;
    /// <summary>
    /// угол в котором выпускаются лучи
    /// </summary>
    private float angle = 65;

    /// <summary>
    /// трансформ игрока
    /// </summary>
    private Transform player;

    /// <summary>
    /// переменная события поимки игрока (event)
    /// </summary>
    public event Action playerDetected;


    void Start()
    {
        StartCoroutine(Find());

    }

    void Update()
    {
        ///проверка, активен ли игрок(объект)
        if (player != null)
        {
            ///проверка на попадание луча в игрока
            if (Vector3.Distance(transform.position, player.position) < distance)
            {
                if (RayToScan())
                {
                    ///вызов события поимки и проверка
                    playerDetected?.Invoke();
                }
            }
        }
    }

    /// <summary>
    /// проверка на попадание луча по дистанции и возврат значения(result)
    /// </summary>
    /// <param name="dir"></param>
    /// <returns></returns>
    bool GetRaycast(Vector3 dir)
    {
        bool result = false;
        RaycastHit hit = new RaycastHit();
        Vector3 pos = transform.position;
        if (Physics.Raycast(pos, dir, out hit, distance))
        {
            if (hit.transform == player)
            {
                result = true;
            }
        }
        return result;
    }

    /// <summary>
    /// проверка на попадание в игрокаи и возврат значения(bool/false)
    /// </summary>
    /// <returns></returns>
    bool RayToScan()
    {
        bool result = false;
        bool a = false;
        bool b = false;
        float j = 0;
        for (int i = 0; i < rays; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += angle * Mathf.Deg2Rad / rays;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
            if (GetRaycast(dir)) a = true;

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-x, 0, y));
                if (GetRaycast(dir)) b = true;
            }
        }

        if (a || b) result = true;
        return result;
    }

    /// <summary>
    /// корутина, пауза для поиска по тэгу
    /// </summary>
    /// <returns></returns>
    IEnumerator Find()
    {
        yield return new WaitForSeconds(2.5f);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}