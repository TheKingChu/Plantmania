using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    //movement and follow player
    public Transform player;
    private Rigidbody2D rb2d;
    private Vector2 movement;
    public float speed = 10f;

    //stats
    public int health;
    //public Slider healthSlider;
    public int attackStrength;
    public int defence;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb2d.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        EnemyMovement(movement);
    }

    private void EnemyMovement(Vector2 direction)
    {
        rb2d.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
