using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    //private bool _isMoving;
    [SerializeField] private float _speed = 3f;

    private void Update()
    {
        if(!IsOwner) return;
        MovePlayer();
    }

    /*private void CheckMovement()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        _isMoving = (horizontal != 0) || (vertical != 0);

        if(!_isMoving) return;

        MovePlayer(vertical, horizontal);
    }

        private void MovePlayer(float vertical, float horizontal)
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        forward *= vertical * _speed;
        right *= horizontal * _speed;

        _moveDirection = forward + right;

        _rigidbody.linearVelocity = _moveDirection;
    }*/

    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(0,0,0);

        if (Input.GetKey(KeyCode.W)) moveDirection.z += 1f;
        if (Input.GetKey(KeyCode.S)) moveDirection.z -= 1f;
        if (Input.GetKey(KeyCode.A)) moveDirection.x -= 1f;
        if (Input.GetKey(KeyCode.D)) moveDirection.x += 1f;

        transform.position += moveDirection*_speed * Time.deltaTime;
    }
}
