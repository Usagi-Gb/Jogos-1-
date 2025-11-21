using UnityEngine;
using System.Collections.Generic;

public class EnemyWaypointMoviment : MonoBehaviour
{
    [Header("Waipoints")]
    public List<Transform> Waipoints;
    [Header("Moviment Settings")]
    public float moveSpeed = 3f;
    public float waypointReachedDistance = 0.1f;
    public bool loop = true;

    private Rigidbody2D rg;
    private int currentWaypointIndex = 0;
    private Vector2 movimentDirection; 
}
void Start() {
    rb = GetComponent<Rigidbody2D>();
    if(waypoint == null || waypoint.Count == 0){
        Debug.LogError("No waypoints assigned to the enemy!");
        enabled = false;
        return;
    }
    SetTargetWaypoint(currentWaypointIndex);
}
void FixedUpdate(){
    MoveTowardsWaypoint();
    CheckIfWaypointReached();
}
void SetTargetWaypoint(int index){
    if (waypoint.Count == 0) return;
    
}