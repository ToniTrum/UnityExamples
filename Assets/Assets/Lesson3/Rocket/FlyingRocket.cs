using System.Collections;
using UnityEngine;

public class FlyingRocket : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float detonationTime;
    [SerializeField] GameObject explosion;
    [SerializeField] float damage = 30f;

    void Awake()
    {
        StartCoroutine(Move());
        StartCoroutine(Detonate());
    }


    IEnumerator Move()
    {
        while (true)
        {
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator Detonate()
    {
        yield return new WaitForSeconds(detonationTime);
        Debug.Log("Detonated");
        Destroy(Instantiate(explosion, transform.position, transform.rotation), explosion.GetComponent<ParticleSystem>().main.duration);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HealthSystem>(out var health))
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
