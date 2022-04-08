using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

    Vector2 movement; 
    public float moveSpeed = 3f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        transform.position = new Vector3(
            transform.position.x + movement.x * moveSpeed * Time.deltaTime,
            transform.position.y + movement.y * moveSpeed * Time.deltaTime, 0);
    }
}
