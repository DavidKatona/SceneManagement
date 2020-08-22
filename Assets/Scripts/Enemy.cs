using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private GameObject _target;
    private NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            _navMeshAgent.SetDestination(_target.transform.position);
        }
    }
}
