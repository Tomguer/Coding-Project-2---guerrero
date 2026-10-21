using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int damage = 1;
    void OnTriggerStay(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health != null) health.TakeDamage(damage);
    }
}