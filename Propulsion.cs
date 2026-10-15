using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Propulsion : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float propulsionSpeed = 7f;
    [SerializeField] float propulsionTime;

    float propulsionLeft;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) propulsionLeft = propulsionTime;
        if (propulsionLeft <= 0f) return;
        propulsionLeft -= Time.deltaTime;
        Vector3 step = transform.forward * propulsionSpeed;
        controller.Move(step * Time.deltaTime);
    }
}