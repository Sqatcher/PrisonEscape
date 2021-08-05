using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float sprintSpeed = 20f;
    public float gravity = -20f;
    public float jumpHeight = 3f;

    public Camera playerCam;

    private float playerSpeed = 12f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public GameObject equipmentObject;
    public GameObject spawns;

    Vector3 velocity;
    bool isGrounded;
    int frameCount = 0;



    private void Start()
	{
        //Invoke("Spawn", 2f);
        SetVelocity(0f, 0f, 0f);
    }
	void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // MOVEMENT SECTION

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKey("left shift") && isGrounded)
        {
            playerSpeed = sprintSpeed;
        }
        else
        {
            playerSpeed = speed;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;
        Vector3 log = playerSpeed * Time.deltaTime * move;
        //controller.Move(playerSpeed * Time.deltaTime * move);

        if (Input.GetButtonDown("Jump") && isGrounded)
		{
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}

        velocity.y += gravity * Time.deltaTime;

        if (frameCount < 2)
        {
            frameCount++;
        }
        else
        {
            controller.Move(log);
            controller.Move(velocity * Time.deltaTime);
        }
    }

    public void SetVelocity(float x, float y, float z)
	{
        velocity = new Vector3(x, y, z);
	}
}
