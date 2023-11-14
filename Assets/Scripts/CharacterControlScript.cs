using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlScript : MonoBehaviour
{
    // Configurable
    public float moveSpeed = 5;
    public float jumpForce = 5;
    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;

    // Internal
    private float currentV = 0;
    private float currentH = 0;

    private readonly float interpolation = 10;
    private readonly float walkScale = 0.33f;

    private bool m_wasGrounded;
    private Vector3 m_currentDirection = Vector3.zero;

    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;
    private bool m_jumpInput = false;

    private bool m_isGrounded;

    private List<Collider> m_collisions = new List<Collider>();

    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

    private void Update()
    {
        if (!m_jumpInput && Input.GetKey(KeyCode.Space))
        {
            // TODO this will be called serval times when player jumps once
            EventManager.TriggerEvent<GenericEvent, string>("playerJumping"); // calls the jump sound
            m_jumpInput = true;
        }
    }

    private void FixedUpdate()
    {
        m_animator.SetBool("Grounded", m_isGrounded);
        DirectUpdate();

        m_wasGrounded = m_isGrounded;
        m_jumpInput = false;
    }

    private void DirectUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Transform camera = Camera.main.transform;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            v *= walkScale;
            h *= walkScale;
        }

        currentV = Mathf.Lerp(currentV, v, Time.deltaTime * interpolation);
        currentH = Mathf.Lerp(currentH, h, Time.deltaTime * interpolation);

        Vector3 direction = camera.forward * currentV + camera.right * currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            // TODO is where the character moves?
            // Debug.Log("Moving?");
            // EventManager.TriggerEvent<GenericEvent, string>("playerWalking"); // calls the walking sound
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * interpolation);

            transform.rotation = Quaternion.LookRotation(m_currentDirection);
            transform.position += m_currentDirection * moveSpeed * Time.deltaTime;

            m_animator.SetFloat("MoveSpeed", direction.magnitude);
        }

        JumpingAndLanding();
    }

    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && m_isGrounded && m_jumpInput)
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
        }
    }

    public void ApplyTemporarySpeedBoost(float increaseAmount, float duration)
    {
        float originalSpeed = moveSpeed;
        moveSpeed += increaseAmount;

        StartCoroutine(ResetSpeedAfterDelay(originalSpeed, duration));
    }
    private IEnumerator ResetSpeedAfterDelay(float originalSpeed, float delay)
    {
        yield return new WaitForSeconds(delay);
        moveSpeed = originalSpeed;
    }


}
