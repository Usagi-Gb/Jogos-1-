using UnityEngine;

public class TJump : MonoBehaviour
{
    private Animator anim;
    public float jumpForce;
    void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.gameObject.tag == "Player")
        {
            anim.SetBool("isTouch")
        }
    }

}