   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerId = 0;
    private Player player;
    public bool useController;

    public GameObject crossHair;
    public GameObject arrowPrefab;
    public Animator animator;

    Vector3 movement;
    Vector3 aim;
    bool isAiming;
    bool endOfAiming;

    void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        ProcessInputs();
        AimAndShoot();
        move();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        
        
    }

    private void ProcessInputs()
    {
        if (useController)
        {
            movement = new Vector3(player.GetAxis("MoveHorizontal"), player.GetAxis("MoveVertical"), 0.0f);
            aim = new Vector3(player.GetAxis("AimHorizontal"), player.GetAxis("AimVertical"), 0.0f);
            aim.Normalize();
            isAiming = player.GetButton("Fire");
            endOfAiming = player.GetButtonDown("Fire");
            

        }
        else
        {
            movement = new Vector3(player.GetAxis("MoveHorizontal"), player.GetAxis("MoveVertical"), 0.0f);

            Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);
            aim = aim + mouseMovement;
            if (aim.magnitude > 1.0f)
            {
                aim.Normalize();
            }
            isAiming = Input.GetButton("Fire1");
            endOfAiming = Input.GetButtonUp("Fire1");
        }

        if(movement.magnitude > 1.0f)
        {
            movement.Normalize();
        }


        
        
    }
    
    private void move()
    {
        transform.position = transform.position + movement * Time.deltaTime;
    }



    private void AimAndShoot()
    {
        
        Vector2 shootingDirection = new Vector2(aim.x, aim.y);

        if (aim.magnitude > 0.0f)
        {
            crossHair.transform.localPosition = aim * 0.4f; 
            crossHair.SetActive(true);


            shootingDirection.Normalize();
            if (endOfAiming)
            {
                GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
                arrow.GetComponent<Rigidbody2D>().velocity = shootingDirection * 5.0f;
                arrow.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
                Destroy(arrow, 2.0f);
            }
        }
        else crossHair.SetActive(false);
    }

}
