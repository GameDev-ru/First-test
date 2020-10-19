using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiEvents : MonoBehaviour
{
    /// <summary>
    /// Обращаемся к Animator NextLevel
    /// </summary>
    [SerializeField] private Animator nextLevelClose = default;
    /// <summary>
    /// Обращаемся к Animator Restart
    /// </summary>
    [SerializeField] private Animator gameOverClose = default;

    /// <summary>
    /// Объект Finish
    /// </summary>
    [SerializeField] private GameObject finish = default;
    /// <summary>
    /// Объект GameOver
    /// </summary>
    [SerializeField] private GameObject _gameOverClose = default;

    /// <summary>
    /// Событие, срабатывающее при нажатии в меню NextLevel
    /// </summary>
    public void NextLevel()
    {
        /// Вызов корутины Next
        StartCoroutine(Next());
    }

    /// <summary>
    /// Событие, срабатывающее при нажатии в меню Restart
    /// </summary>
    public void Restart()
    {
        /// Выхов корутины RestartClose
        StartCoroutine(RestartClose());
    }

    /// <summary>
    /// Анимация скрытия меню и перезагрузка уровня
    /// </summary>
    /// <returns></returns>
    IEnumerator RestartClose()
    {
        /// Проверка активности объекта
        if (!_gameOverClose.activeSelf)
        {
            nextLevelClose.SetTrigger("Close");
        }

        /// Проверка активности объекта
        if (!finish.activeSelf)
        {
            gameOverClose.SetTrigger("Close");
        }

        /// Пауза
        yield return new WaitForSeconds(1.5f);

        /// Перезагрузка сцены
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Загрузка следюющего уровня
    /// </summary>
    /// <returns></returns>
    IEnumerator Next()
    {
        /// Проверка имени сцены и загрузка следующей

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            nextLevelClose.SetTrigger("Close");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("Level2");
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            nextLevelClose.SetTrigger("Close");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("Level3");
        }
    }
}
