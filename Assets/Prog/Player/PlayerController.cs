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
    public bool arcbool;
    public bool sword;
    public static PlayerController instance;
    #region GameObject
    public GameObject crossHair;
    public GameObject arrowPrefab;
    #endregion

    public Animator animator;

    //sword


    Vector3 movement;
    Vector3 aim;
    bool isAiming;
    public bool endOfAiming;
    public bool crosshairbool;

    void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
        animator.SetBool("Arc", false);
        animator.SetBool("Sword", false);

        arcbool = false;

        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    // Update is called once per frame


    void Update()
    {

        ProcessInputs();
        AimAndShoot();
        move();
        crosshairfalse();




    }

    private void ProcessInputs()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);
        if (useController)
        {
            movement = new Vector3(player.GetAxis("MoveHorizontal"), player.GetAxis("MoveVertical"), 0.0f);
        }
        else
        {
            movement = new Vector3(player.GetAxis("MoveHorizontal"), player.GetAxis("MoveVertical"), 0.0f);
        }
        //------------------------------------------------------------------------------------------------------
        if (arcbool)
        {
            animator.SetBool("Arc", true);
            animator.SetBool("Sword", false);

            if (useController)
            {
                movement = new Vector3(player.GetAxis("MoveHorizontal"), player.GetAxis("MoveVertical"), 0.0f);
                aim = new Vector3(player.GetAxis("AimHorizontal"), player.GetAxis("AimVertical"), 0.0f);
                aim.Normalize();
                isAiming = player.GetButton("Fire");
                endOfAiming = player.GetButtonUp("Fire");
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

            if (movement.magnitude > 1.0f)
            {
                movement.Normalize();

            }

        }
        



        if (sword)
        {
            animator.SetBool("Arc", false);
            animator.SetBool("Sword", true);




        }





    }


    
        
        

    

    private void move()
    {
        transform.position = transform.position + movement * Time.deltaTime;
    }

    public void crosshairfalse()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            crossHair.SetActive(false);
            
        }

        if (crosshairbool == false)
        {
            crossHair.SetActive(false);

        }
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
        else
        {
            crossHair.SetActive(false);
        }

            
    }

    public void ArcUpdate()
    {
        arcbool = true;
        Debug.Log("Tu a équipé");
    }


}



//        Cursor.lockState = CursorLockMode.Locked;
//Cursor.visible = false;