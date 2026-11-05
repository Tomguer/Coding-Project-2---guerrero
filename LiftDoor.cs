using Unity.VectorGraphics;
using UnityEngine;

public class LiftDoor : MonoBehaviour
{
    [SerializeField] float openHeight = 3f;
        bool isOpen;
    bool isDown;

    bool isHurt;

    [SerializeField] Collider solid;        
    [SerializeField] Renderer look;

    public void Open()
    {
        if (isOpen) return;
        isOpen = true;
        transform.Translate(0, openHeight, 0);
    }

    public void Down()
    {
        if (isDown) return;
        look.enabled = true;
        solid.enabled = true;
    }

    public void Hurt()
    {
        if (isHurt) return;
        look.enabled = true;
        solid.enabled = true;
    }
}
