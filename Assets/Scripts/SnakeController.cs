using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;


public class SnakeController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> tails;
    [SerializeField]
    private float boneDistance;
    [SerializeField]
    private GameObject bonePref;
    [SerializeField] 
    private float speed;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        MoveSnake(_transform.position + _transform.forward * speed);
        float angel = Input.GetAxis("Horizontal") * 1;
        _transform.Rotate(0, angel,0);
    }

    private void MoveSnake(Vector3 newPosition)
    {
        var sqrDistance = boneDistance * boneDistance;
        Vector3 previousBonePosition = _transform.position;

        foreach (var bone in tails)
        {
            if ((bone.position - previousBonePosition).sqrMagnitude > sqrDistance)
            {
                (bone.position, previousBonePosition) = (previousBonePosition, bone.position);
            }
        }
        _transform.position = newPosition;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food") )
        {
            Food.Instance.Spawn();
        }
        else
        {
            Death();
        }

    }
    private void Death()
    {
        Debug.Log("Death");
    }
    
}