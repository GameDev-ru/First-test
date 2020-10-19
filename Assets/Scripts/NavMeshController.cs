using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    /// <summary>
    /// переменные события
    /// </summary>
    private enum State
    {
        None,
        /// <summary>
        /// стоит
        /// </summary>
        Stay,
        /// <summary>
        /// идет ко 2й цели
        /// </summary>
        _Move1,
        /// <summary>
        /// идет к 1й цели
        /// </summary>
        _Move2
    }
    private State state;

    /// <summary>
    /// переменная для охраны по типу
    /// </summary>
    [SerializeField] [Range(1, 2)] private int guard = default;

    /// <summary>
    /// переменная NavMeshAgent
    /// </summary>
    private NavMeshAgent agent;

    /// <summary>
    /// 1я цель к которой пойдет охрана
    /// </summary>
    [SerializeField] private GameObject target1 = default;
    /// <summary>
    /// 2я цель к которой пойдет охрана
    /// </summary>
    [SerializeField] private GameObject target2 = default;

    /// <summary>
    /// переменная для проверки и указания цели
    /// </summary>
    private GameObject targetToMove;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetToMove = target2;
        state = State.Stay;
        StartCoroutine(Move());
    }

    /// <summary>
    /// вызов корутины-события для передвижения охраников
    /// </summary>
    /// <returns></returns>
    IEnumerator Move()
    {
        while (true)
        {
            switch (state)
            {
                case State.Stay:
                    yield return StartCoroutine(Stay());
                    break;
                case State._Move1:
                    agent.destination = targetToMove.transform.position;
                    targetToMove = target2;
                    state = State.Stay;
                    break;
                case State._Move2:
                    agent.destination = targetToMove.transform.position;
                    targetToMove = target1;
                    state = State.Stay;
                    break;
            }
            yield return null;
        }
    }

    /// <summary>
    /// вызов корутины когда охраник стоит
    /// </summary>
    /// <returns></returns>
    IEnumerator Stay()
    {
        int time = default;

        if (guard == 1)
        {
            time = Random.Range(3, 6);
        }
        if (guard == 2)
        {
            time = Random.Range(4, 9);
        }

        yield return new WaitForSeconds(time);

        if (targetToMove == target2)
        {
            state = State._Move2;
        }
        else
            state = State._Move1;
    }
}
