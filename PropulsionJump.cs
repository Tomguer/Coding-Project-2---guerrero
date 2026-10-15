using UnityEngine;

public class PropulsionJump : MonoBehaviour
{

    [SerializeField] CharacterController controller;
    [SerializeField] float blastHeight;
    [SerializeField] float blastTime;
    float blastUp;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) blastUp = blastTime;
        if (blastUp <= 0f) return;
        blastUp -= Time.deltaTime;
        {
            Vector3 up = transform.up * blastHeight;
            controller.Move(up * Time.deltaTime);      
        }

    }
}
