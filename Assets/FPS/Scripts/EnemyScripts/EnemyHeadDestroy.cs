using UnityEngine;

public class EnemyHeadDestroy : MonoBehaviour
{
    public GameObject impactEffect;
    private GameObject _gameObject;
    private Transform _transform;
    void Start()
    {
        _gameObject = GetComponent<GameObject>();
        _transform = GetComponent<Transform>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Bullet"))
        {
            Debug.Log("Head is destroyed");
            Destroy(_gameObject);
            Instantiate(impactEffect, _transform.position, _transform.rotation);
        }
    }
}
