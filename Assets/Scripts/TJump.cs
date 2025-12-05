using UnityEngine;

public class TJump : MonoBehaviour
{
    public float jumpForce;
    void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.gameObject.tag == "Player")
        {
            Debug.Log(collsion.gameObject.name);
            collsion.gameObject.SendMessage("Jump", jumpForce);
        }
    }

}