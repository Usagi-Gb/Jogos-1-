using UnityEngine;
using System.Collections.Generic;

public class EnemyWaypointMoviment : MonoBehaviour
{
    [Header("Waipoints")]
    public List<Transform> Waipoints;
    [Header("Moviment Settings")]
    public float moveSpeed = 3f;
    public float waipointReachedDistance = 0.1f;
    public bool loop = true;

    private Rigidbody2D rg;
    private int currentWaypointIndex = 0;
    private Vector2 movimentDirection; 
}
void Start() {
    rb = GetComponent<Rigidbody2D>();
    if(waipoint == null || waipoint.Count == 0){
        Debug.LogError
    }
}