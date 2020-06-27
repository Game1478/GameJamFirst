using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerMovement : MonoBehaviour
{
    

    public Animator animator;
    public AudioClip jumpClip;
    public AudioSource audioSource;

    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float jumpForce = 5;

    Rigidbody m_rigidobdy;
    Vector3 movementDiraction = Vector3.zero;

    [SerializeField] private KeyCode moveRightLetter = KeyCode.None;
    [SerializeField] private KeyCode moveLeftLetter = KeyCode.None;
    [SerializeField] private KeyCode jumpLetter = KeyCode.None;

    [SerializeField] private bool onGround;

    void Start()
    {
        m_rigidobdy = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(moveRightLetter))
        {
            movementDiraction = Vector3.right;
            animator.SetTrigger("Run");
            animator.SetBool("StartRun", true);
        }
        else if (Input.GetKey(moveLeftLetter))
        {
            movementDiraction = Vector3.left;
            animator.SetTrigger("Run");
            animator.SetBool("StartRun", true);
        }
        else
        {
            movementDiraction = Vector3.zero;
            animator.SetTrigger("StopRun");
            animator.SetBool("StartRun", false);
        }
    }

    private void FixedUpdate()
    {
        m_rigidobdy.MovePosition(transform.position + movementDiraction * movementSpeed * Time.fixedDeltaTime);
        if (Input.GetKeyDown(jumpLetter) && onGround)
        {
            m_rigidobdy.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump");
            audioSource.PlayOneShot(jumpClip);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12) //layer of ground at my project
        {
            onGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 12) //layer of ground at my project
        {
            onGround = false;
        }
    }

}
