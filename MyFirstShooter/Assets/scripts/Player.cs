using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : LivingEntity
{
    public float moveSpeed = 5;
    Camera _viewCamera;
    PlayerController _controller;
    private GunController _gunController;
    protected override void Start()
    { 
        base.Start();
        _controller = GetComponent<PlayerController>();
        _gunController = GetComponent<GunController>();
        _viewCamera = Camera.main;   }

    void Update()
    {
        //movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        _controller.Move(moveVelocity);
        
        //look input
        Ray ray = _viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
                //Debug.DrawLine(ray.origin, point, Color.red);
                _controller.LookAt(point);
        }
        
        //weapon input
        if (Input.GetMouseButton(0))
        {
            _gunController.Shoot();
            
            
        }
    }
} 
