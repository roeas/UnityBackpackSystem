using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bag;
    public float speed;

    private Rigidbody2D body;
    private new Collider2D collider;
    private Animator animator;
    private Vector2 movement;
    private bool isOpen;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }
    private void Update() {
        SwitchAnime();
        OpenBag();
    }
    private void FixedUpdate() {
        Movement();
    }
    void Movement() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement * speed * Time.fixedDeltaTime;
        body.velocity = new Vector2(movement.x, movement.y);
    }
    void SwitchAnime() {
        if (movement != Vector2.zero) {//保证Horizontal归0时，保留movment的值来切换idle动画的blend tree
            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);
        }
        animator.SetFloat("speed", movement.sqrMagnitude);
    }
    void OpenBag() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (bag.activeSelf) {
                bag.SetActive(false);
            }
            else {
                bag.SetActive(true);
            }
        }
    }
}