using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private Joystick _leftJoystick;
    private Joystick _rightJoystick;

    private PhotonView _photonView;
    
    // Start is called before the first frame update
    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        FindJoysticks();
    }

    // Update is called once per frame
    void Update()
    {
        if(_photonView.IsMine)
            MovePlayer();
    }

    // Move player 
    private void MovePlayer()
    {
        if (_leftJoystick.Direction == Vector2.zero) return;
        
        transform.Translate(
            _leftJoystick.Direction.normalized * moveSpeed * Time.deltaTime
            );
    }
    
    
    // Finds joystick controllers in scene (when player spawned)
    private void FindJoysticks()
    {
        GameObject[] joysticks = GameObject.FindGameObjectsWithTag("Joystick");

        foreach (GameObject joystick in joysticks)
        {
            if (joystick.gameObject.name.StartsWith("Left"))
            {
                _leftJoystick = joystick.GetComponent<Joystick>();
            }
            else if (joystick.gameObject.name.StartsWith("Right"))
            {
                _rightJoystick = joystick.GetComponent<Joystick>();
            }
        }
    }
    
    
}
