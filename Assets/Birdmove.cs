using UnityEngine;

public class Birdmove : MonoBehaviour {
    Vector3 velocity = Vector3.zero;
    float flapSpeed = 100f;
    bool didFlap = false;
    public float forwardSpeed = 1f;
    public bool dead = false;
    Animator animator;
    float deathCooldown;

    // Use this for initialization
    void Start()
    {
        animator = transform.GetComponentInChildren<Animator>();

        if (animator == null)
        {
            Debug.LogError("Didn't find animator!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            deathCooldown -= Time.deltaTime;
            if (deathCooldown <= 0)
            {
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                didFlap = true;
            }
        }
    }


        void FixedUpdate() {
        if (dead)
            return;
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * forwardSpeed);
        Debug.Log(GetComponent<Rigidbody2D>().velocity);
        if (didFlap)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapSpeed);
            animator.SetTrigger("DoFlap");
            didFlap = false;
        }

        if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float angle = Mathf.Lerp(0, -90, (-GetComponent<Rigidbody2D>().velocity.y / 3f));
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Death");
        dead = true;
        deathCooldown = 0.5f;

        
    }

}
