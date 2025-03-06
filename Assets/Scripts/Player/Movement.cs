using Photon.Pun;
using UnityEngine;
[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody _rb;
    private PhotonView photonView;

    private Vector3 moveDirection;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)return;
        MoveDirection();
        Move();
    }

    private void MoveDirection()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");

        moveDirection.y = 0;

        moveDirection *= speed;
    }

    private void Move()
    {
        _rb.linearVelocity = new Vector3(moveDirection.x, _rb.linearVelocity.y, moveDirection.z);
    }
}