using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public static MoveByTouch instance;
    public float baseSpeed = 5f;
    float speed;
    public float speedBoots = 1f;
    public float speedMutilple = 1f;
    [SerializeField] Joystick joystick;
    Rigidbody2D rb;
    Vector2 input;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = baseSpeed;
        speedBoots = 1f;
    }
    void Update()
    {
        speed = baseSpeed;

        input.x = joystick.Horizontal;
        input.y = joystick.Vertical;
        input.Normalize();
        if (input == Vector2.zero)
        {
            PlayerController.instance.SetAnimationIdle();
        }
        else if (input != Vector2.zero)
        {
            PlayerController.instance.SetAnimationMove();
        }
        rb.velocity = input * speed * speedBoots * speedMutilple;
    }

    public Vector2 ReturnInputDir()
    {
        return input;
    }
}
