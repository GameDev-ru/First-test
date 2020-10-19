using UnityEngine;

public class Key : MonoBehaviour
{
    /// <summary>
    /// Объект Lattice
    /// </summary>
    [SerializeField]
    private GameObject target = default;


    private void OnTriggerEnter(Collider other)
    {
        // проверка по тэгу игрока
        if (other.CompareTag("Player"))
        {
            // проверка наличия объекта
            if (target != null)
            {
                // разрушение цели(Lattice)
                Destroy(target);
            }
        }
    }
}
