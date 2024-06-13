using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Playermovement : MonoBehaviour
{
    
    public Rigidbody2D rb;
    
    public GameObject arrowPrefab;
    public GameObject firePoint;
    public GameObject SpecialarrowPrefab;
    public DamageController Damagesystem;
    private Image SpecialAttackCooldown;
    private Image SpaceCooldown;
    
   

    bool IscooldownSpecialArcher;
    bool SpaceAttack = false;
    //public bool IsAvailable = true;
    //public float CooldownDuration = 0.1f;
   
   
    
  
public float inputHorizontal;
public float inputVertical;
    public char ShootWay;

    Animator animator;
    string currentState;
    const string PLAYER_IDLE = "Player-Idle";
    const string PLAYER_WALK_LEFT = "Player-left";
    const string PLAYER_WALK_RIGHT= "Player-right";
    const string PLAYER_WALK_UP = "Player-up";
    const string PLAYER_WALK_DOWN = "Player-down";



    void Start()
    {
        //   player =
        Damagesystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DamageController>();

        animator = gameObject.GetComponent<Animator>();
        SpaceCooldown = GameObject.Find("SpaceCooldown").GetComponent<Image>();
        if (PlayerPrefs.GetString("Char") == "Archer")
        {
            SpecialAttackCooldown = GameObject.Find("CooldownArcher").GetComponent<Image>();
            
        }
    }
    // Update is called once per frame
    void Update()
    {
     
            
        inputHorizontal = Input.GetAxisRaw("Horizontal");
       inputVertical= Input.GetAxisRaw("Vertical");
        if (IscooldownSpecialArcher == true)
        {

            SpecialAttackCooldown.fillAmount += 1 / Damagesystem.ArcherSpecialCooldown * Time.deltaTime;

            if (SpecialAttackCooldown.fillAmount >= 1)
            {
                SpecialAttackCooldown.fillAmount = 0;
                IscooldownSpecialArcher = false;
            }
        }

        if (SpaceAttack == true)
        {

            SpaceCooldown.fillAmount += 1 / Damagesystem.ArcherSpaceCooldown * Time.deltaTime;

            if (SpaceCooldown.fillAmount >= 1)
            {
                SpaceCooldown.fillAmount = 0;
                SpaceAttack = false;
            }
        }


        if (IscooldownSpecialArcher == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Specialattack();

            }

        }
        


        if (SpaceAttack == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                attack();
            }
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            ShootWay = 'S';
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ShootWay = 'W';
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShootWay = 'A';
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ShootWay = 'D';
        }
       
    }
    void FixedUpdate()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= Damagesystem.PlayerLimitSpeed;
                inputVertical *= Damagesystem.PlayerLimitSpeed;
            }

        rb.velocity = new Vector2(inputHorizontal * Damagesystem.PlayerMoveSpeed, inputVertical * Damagesystem.PlayerMoveSpeed);
        
        if (inputHorizontal > 0)
        {
            ChangeAnimationState(PLAYER_WALK_RIGHT);
        }
        else if (inputHorizontal < 0)
        {
            ChangeAnimationState(PLAYER_WALK_LEFT);
        }
        else if (inputVertical > 0)
        {
            ChangeAnimationState(PLAYER_WALK_UP);
        }
        else if (inputVertical < 0)
        {
            ChangeAnimationState(PLAYER_WALK_DOWN);
        }
     /*   
        else if (inputHorizontal < 0 || inputVertical > 0)          // A W
        {
            ChangeAnimationState(PLAYER_WALK_LEFT);
        }
          else if (inputHorizontal > 0 || inputVertical < 0)                            // S D
        {
            ChangeAnimationState(PLAYER_WALK_RIGHT);
        }
        else if (inputHorizontal < 0 || inputVertical < 0)                  // A S
        {
            ChangeAnimationState(PLAYER_WALK_LEFT);
        }
        else if (inputHorizontal > 0 || inputVertical > 0)                            // W D
        {
            ChangeAnimationState(PLAYER_WALK_RIGHT);
        }
        */
        }
        else
        {
             rb.velocity = new Vector2(0f , 0f);
             ChangeAnimationState(PLAYER_IDLE);
        }
    }
    private void ChangeAnimationState(string newState)
    {
        //stop animation
        if (currentState == newState) return;

//new animation
    animator.Play(newState);

    //Update
    currentState = newState;



    }
    void Specialattack()
    {
            if (PlayerPrefs.GetString("Char") == "Archer")
            {
            
            IscooldownSpecialArcher = true;


            
                Quaternion Rot = Quaternion.Euler(new Vector3(0f, 0f, 135f));
                GameObject arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Rot);

                arrowInstance.GetComponent<Rigidbody2D>().AddForce(Rot * Vector2.right * Damagesystem.VelocityArrow, ForceMode2D.Impulse);



            
                 Rot = Quaternion.Euler(new Vector3(0f, 0f, 45f));
                 arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Rot);

                arrowInstance.GetComponent<Rigidbody2D>().AddForce(Rot * Vector2.right * Damagesystem.VelocityArrow, ForceMode2D.Impulse);

           
                 Rot = Quaternion.Euler(new Vector3(0f, 0f, 225f));
                 arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Rot);

                arrowInstance.GetComponent<Rigidbody2D>().AddForce(Rot * Vector2.right * Damagesystem.VelocityArrow, ForceMode2D.Impulse);

            
                 Rot = Quaternion.Euler(new Vector3(0f, 0f, 315f));
                 arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Rot);

                arrowInstance.GetComponent<Rigidbody2D>().AddForce(Rot * Vector2.right * Damagesystem.VelocityArrow, ForceMode2D.Impulse);

            
                 arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Quaternion.identity);

                arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Damagesystem.VelocityArrow, ForceMode2D.Impulse);

            
                 Rot = Quaternion.Euler(new Vector3(0f, 0f, 90f));
                 arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Rot);

                arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Damagesystem.VelocityArrow, ForceMode2D.Impulse);

            
                 Rot = Quaternion.Euler(new Vector3(0f, 0f, 180f));
                 arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Rot);

                arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.left * Damagesystem.VelocityArrow, ForceMode2D.Impulse);

            
                 Rot = Quaternion.Euler(new Vector3(0f, 0f, 270f));
                 arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Rot);
           
                arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.down * Damagesystem.VelocityArrow, ForceMode2D.Impulse);
            
         


        }

    }







        void attack()
    {
        


            if (PlayerPrefs.GetString("Char") == "Archer")
            {
            SpaceAttack = true;

                
                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
                {
                    Quaternion Rot = Quaternion.Euler(new Vector3(0f, 0f, 135f));
                    GameObject arrowInstance = Instantiate(arrowPrefab, transform.position, Rot);

                    arrowInstance.GetComponent<Rigidbody2D>().AddForce(Rot * Vector2.right * Damagesystem.VelocityArrow, ForceMode2D.Impulse);
                    


                }
                else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
                {
                    Quaternion Rot = Quaternion.Euler(new Vector3(0f, 0f, 45f));
                    GameObject arrowInstance = Instantiate(arrowPrefab, transform.position, Rot);

                    arrowInstance.GetComponent<Rigidbody2D>().AddForce(Rot * Vector2.right * Damagesystem.VelocityArrow, ForceMode2D.Impulse);
                    
                }
                else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
                {
                    Quaternion Rot = Quaternion.Euler(new Vector3(0f, 0f, 225f));
                    GameObject arrowInstance = Instantiate(arrowPrefab, transform.position, Rot);

                    arrowInstance.GetComponent<Rigidbody2D>().AddForce(Rot * Vector2.right * Damagesystem.VelocityArrow, ForceMode2D.Impulse);
                    
                }
                else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
                {
                    Quaternion Rot = Quaternion.Euler(new Vector3(0f, 0f, 315f));
                    GameObject arrowInstance = Instantiate(arrowPrefab, transform.position, Rot);

                    arrowInstance.GetComponent<Rigidbody2D>().AddForce(Rot * Vector2.right * Damagesystem.VelocityArrow, ForceMode2D.Impulse);
                    
                }


                else if (ShootWay == 'D' || Input.GetKeyDown(KeyCode.D))
                {
                    GameObject arrowInstance = Instantiate(arrowPrefab, transform.position, Quaternion.identity);

                    arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Damagesystem.VelocityArrow, ForceMode2D.Impulse);
                    
                }

                else if (ShootWay == 'W' || Input.GetKeyDown(KeyCode.W))
                {
                    Quaternion Rot = Quaternion.Euler(new Vector3(0f, 0f, 90f));
                    GameObject arrowInstance = Instantiate(arrowPrefab, transform.position, Rot);

                    arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Damagesystem.VelocityArrow, ForceMode2D.Impulse);
                    
                }

                else if (ShootWay == 'A' || Input.GetKeyDown(KeyCode.A))
                {
                    Quaternion Rot = Quaternion.Euler(new Vector3(0f, 0f, 180f));
                    GameObject arrowInstance = Instantiate(arrowPrefab, transform.position, Rot);

                    arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.left * Damagesystem.VelocityArrow, ForceMode2D.Impulse);
                    
                }
                else if (ShootWay == 'S' || Input.GetKeyDown(KeyCode.S))
                {
                    Quaternion Rot = Quaternion.Euler(new Vector3(0f, 0f, 270f));
                    GameObject arrowInstance = Instantiate(arrowPrefab, transform.position, Rot);
                    //   arrowInstance.GetComponent<Rigidbody2D>().AddTorque(180, ForceMode2D.Impulse);
                    arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.down * Damagesystem.VelocityArrow, ForceMode2D.Impulse);
                   
                }



                //velocity = new Vector2(100.0f, 0.0f);   //AddForce(Vector2.right * velocity, ForceMode2D.Impulse);
            }
        
    }
  /*  public IEnumerator StartCooldown()
    {
        IsAvailable = false;
        yield return new WaitForSeconds(CooldownDuration);
        IsAvailable = true;
    } */
}

