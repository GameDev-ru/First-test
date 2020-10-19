using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad
{
    private static string path = Application.persistentDataPath + "Level.save";
    private static BinaryFormatter formatter = new BinaryFormatter();

    public static void SaveGame(string _level)
    {

        FileStream fs = new FileStream(path, FileMode.Create);

        LevelSave data = new LevelSave(_level); //Получение данных

        formatter.Serialize(fs, data); //Сериализация данных

        fs.Close();
    }

    public static LevelSave LoadGame() //Метод загрузки
    {
        if (File.Exists(path))
        { // Проверка существования файла сохранения
            FileStream fs = new FileStream(path, FileMode.Open); // Открытие потока

            LevelSave data = formatter.Deserialize(fs) as LevelSave; // Получение данных

            fs.Close(); // Закрытие потока

            return data; // Возвращение данных
        }

        return null; // Если файл не существует, будет возвращено null
    }
}
