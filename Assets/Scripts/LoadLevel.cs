using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    private LevelSave data;

    void Awake()
    {
        data = SaveLoad.LoadGame();
        if (SceneManager.GetActiveScene().name != data.level)
        Load();
    }

    public void Load()
    {
        //Получение данных

        if (!data.Equals(null)) //Если данные есть
        {
            SceneManager.LoadScene(data.level);
        }
    }
}
