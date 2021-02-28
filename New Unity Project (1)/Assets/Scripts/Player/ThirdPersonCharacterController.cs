using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class ThirdPersonCharacterController : NetworkBehaviour
{
    public float speed;
    private Rigidbody body;
    public LayerMask groundLayers;
    public float jumpForce = 7;
    public BoxCollider col;
    public Text debugger;
    public BoxCollider feet;

    void Start() 
    {
        body = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    [Client]
    private void Update()
    {
        if (!hasAuthority) 
        { return; } 
        
        debugger.text = "Grounded:" + IsGrounded();
        MovePlayer();
    }

    void MovePlayer() 
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) 
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded() 
    {
        return Physics.CheckBox(feet.bounds.center, feet.bounds.extents, Quaternion.identity, groundLayers);
    }
}
