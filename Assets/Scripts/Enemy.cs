using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Security.Policy;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    float speed = .5f;
    public UnityEngine.AI.NavMeshAgent zombie;
    List<UnityEngine.AI.NavMeshAgent> horde = new List<UnityEngine.AI.NavMeshAgent>();
    List<Vector3> hordePositions = new List<Vector3>();
    //Rigidbody rb;
    GameManager gameManager;
    GameObject player;
    int state = 0;
    int health = 2;
    
    float wanderRadius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //rb = GetComponent<Rigidbody>();
        zombie = GetComponent<UnityEngine.AI.NavMeshAgent>();
        zombie.destination = this.gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 0)
        {
            Wander();
        }
        else if ( state == 1)
        {
            Chase();
        }
        else if (state == 2)
        {
            Attack();
        }
    }

    public void Wander()
    {
        zombie.speed = speed;
        if (zombie.destination == new Vector3(this.transform.position.x,this.transform.position.y - zombie.baseOffset, this.transform.position.z))
        {
            zombie.destination = this.transform.position + new Vector3(Random.Range(-2, wanderRadius), 0, Random.Range(-2, wanderRadius));
        }
        

        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            state = 2;
            Debug.Log(state);
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            state = 1;
            Debug.Log(state);
        }
    }

    public void Chase()
    {
        zombie.destination = player.transform.position;
        zombie.speed = 1f;

    }

    public void Attack()
    {
        gameManager.playerHealth -= 1;
        state = 0;
        Debug.Log(state);
    }
}
