using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed;


    public Transform target;

    public GameObject Player;
    public GameObject Minion;
    public GameObject Bariera;
    public Transform Boss;
    public HealthBar healthBar;
    public Transform MiddleLocation;
    public DamageController Damagesystem;

    Animator animator;
    private bool KontrolaSpawnutia = true;
    public GameObject SpawnLocation;

    
    
    public bool minionAlive = true;
    public bool minionSpawned = false;

    // Start is called before the first frame update



    void Start()
       
    {

        Damagesystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DamageController>();

        PlayerPrefs.SetString("Damage", "true");
        healthBar = GameObject.FindGameObjectWithTag("HealthBarBoss").GetComponent<HealthBar>();

        animator = gameObject.GetComponent<Animator>();

    }
    private void FixedUpdate()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Boss = GameObject.FindGameObjectWithTag("BOSS").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {

        Player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Boss = GameObject.FindGameObjectWithTag("BOSS").GetComponent<Transform>();

        if (healthBar.FindHealth() >= Damagesystem.SlimeHealthFor1Rotation && healthBar.FindHealth() <= Damagesystem.BossMaxHealth)
        {
            speed = Damagesystem.SlimeNormalSpeed;
        Vector2 targetvector = (Player.transform.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }


        else if ( healthBar.FindHealth() <= Damagesystem.SlimeHealthFor1Rotation-1 && minionAlive == true)
        {
            PlayerPrefs.SetString("Damage", "false");
            speed = 300f;
            MiddleLocation = GameObject.FindGameObjectWithTag("MiddlePoint").GetComponent<Transform>();
            Vector2 targetvector2 = (MiddleLocation.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, MiddleLocation.position, speed * Time.deltaTime);
      

            if (KontrolaSpawnutia == true && transform.position == MiddleLocation.transform.position)
            {
                
                minionSpawn();
                KontrolaSpawnutia = false;
                minionSpawned = true;
                Bariera = (GameObject)Resources.Load("Bariera", typeof(GameObject));
                GameObject.Instantiate(Bariera, Boss.transform.position, Quaternion.identity);
                

            }
            if (GameObject.FindGameObjectWithTag("Minion") == false && minionSpawned == true)
            {
                PlayerPrefs.SetString("Damage", "true");
              
                minionAlive = false;
                Destroy(GameObject.FindGameObjectWithTag("Bariera"));
            }
                
         
    
          
        }

        else if (minionAlive == false && healthBar.FindHealth()<= Damagesystem.SlimeHealthFor1Rotation && healthBar.FindHealth() >= Damagesystem.SlimeHealthFor2Rotation )

        {
            speed = Damagesystem.SlimeSpeedIn2rotation;
            Vector2 targetvector = (Player.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
         else if(healthBar.FindHealth() <= Damagesystem.SlimeHealthFor2Rotation-1)
        {
            speed = Damagesystem.SlimeSpeedIn3rotation;
            Vector2 targetvector = (Player.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }




    }
    public void minionSpawn()
    {
        SpawnLocation = GameObject.FindGameObjectWithTag("MinionSpawn1");
        Minion = (GameObject)Resources.Load("BabySlime", typeof(GameObject));
        GameObject.Instantiate(Minion, SpawnLocation.transform.position, Quaternion.identity);

        SpawnLocation = GameObject.FindGameObjectWithTag("MinionSpawn2");
        
        GameObject.Instantiate(Minion, SpawnLocation.transform.position, Quaternion.identity);
        
        SpawnLocation = GameObject.FindGameObjectWithTag("MinionSpawn3");
        
        GameObject.Instantiate(Minion, SpawnLocation.transform.position, Quaternion.identity);

        SpawnLocation = GameObject.FindGameObjectWithTag("MinionSpawn4");
        
        GameObject.Instantiate(Minion, SpawnLocation.transform.position, Quaternion.identity);

        SpawnLocation = GameObject.FindGameObjectWithTag("MinionSpawn5");
        
        GameObject.Instantiate(Minion, SpawnLocation.transform.position, Quaternion.identity);

        SpawnLocation = GameObject.FindGameObjectWithTag("MinionSpawn6");
        
        GameObject.Instantiate(Minion, SpawnLocation.transform.position, Quaternion.identity);

    }

 

    
}