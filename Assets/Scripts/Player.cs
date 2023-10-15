using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public int health;
    public Rigidbody2D rb;
    public Weapon weapon;

    Vector2 moveDir;
    Vector2 mousePos;

    PhotonView view;



    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if(view.IsMine)
        {
            float movementX = Input.GetAxisRaw("Horizontal");
            float movementY = Input.GetAxisRaw("Vertical");

            if (Input.GetMouseButtonDown(0))
            {
                weapon.Fire();
            }

            moveDir = new Vector2(movementX, movementY).normalized;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);

            Vector2 aimDir = mousePos - rb.position;
            float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle;

        }
    }
}
