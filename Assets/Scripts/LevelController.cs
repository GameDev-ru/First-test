using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    /// <summary>
    /// Меню рестарта
    /// </summary>
    [SerializeField] private GameObject restart = default;

    /// <summary>
    /// Меню финиша
    /// </summary>
    [SerializeField] private GameObject finish = default;

    /// <summary>
    /// объект у которого есть PlayerController
    /// </summary>
    [SerializeField] private PlayerController player = default;

    /// <summary>
    /// массив охраников
    /// </summary>
    [SerializeField] private Scan[] guards = default;

    /// <summary>
    /// подписываемся на события (event)
    /// </summary>
    private void Awake()
    {
        player.onFinish += PlayerOnFinish;
        foreach (var g in guards)
        {
            g.playerDetected += HandlePlayerOnCapture;
        }
    }

    private void Start()
    {
        SaveLoad.SaveGame(SceneManager.GetActiveScene().name);
        // запуск корутины для появления игрока
        StartCoroutine(Play());
    }

    /// <summary>
    /// событие при поимке игрока
    /// </summary>
    private void HandlePlayerOnCapture()
    {
        player.Speed = 0;
        restart.SetActive(true);
    }

    /// <summary>
    /// событие при достижения финиша
    /// </summary>
    private void PlayerOnFinish()
    {
        player.Speed = 0;
        finish.SetActive(true);
    }

    /// <summary>
    /// пауза перед появлением игрока
    /// </summary>
    /// <returns></returns>
    IEnumerator Play()
    {
        yield return new WaitForSeconds(2f);
        player.gameObject.SetActive(true);
    }
}
