using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    [SerializeField] LiftDoor door;
    [SerializeField] LiftDoor ceiling;

    [SerializeField] LiftDoor damage;

        void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        door.Open();

        if (!other.CompareTag("Player")) return;
        ceiling.Down();

        if (!other.CompareTag("Player")) return;
        damage.Hurt();
    }

}
