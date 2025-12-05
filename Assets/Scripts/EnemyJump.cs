using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    public float jumpForce;
    void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.gameObject.tag == "Enemy")
        {
            Debug.Log(collsion.gameObject.name);
            collsion.gameObject.SendMessage("Jump", jumpForce);
        }
    }

}