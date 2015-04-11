using UnityEngine;
using System.Collections;

public class Decision : MonoBehaviour 
{
	enum ActionType {move, jump, wait, attack};

	public float movementSpeed = 3.0f, jumpPower = 100.0f, viewConeAngle = 20.0f, viewConeRange = 3.0f;

    public bool enableDebugRenderer = true;

	private ActionType task;

	private float timer;

    private Vector3 targetPosition;

	// Use this for initialization
	void Start() 
	{
		this.task = ActionType.move;
	}
	
	// Update is called once per frame
	void Update()
	{
		this.timer += Time.deltaTime;

		// Cube left the building
		if (this.transform.position.y < 0.0f)
		{
			this.transform.position = Vector3.up;
		}

		// Choosing new task
		if (this.timer >= 2.0f)
		{
			this.timer = 0.0f;

			this.task = (ActionType) this.ChooseRandomTask();
		}

		// Evaluating the given task
		if (this.task == ActionType.move)
		{
			this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + (this.transform.forward * this.movementSpeed), Time.deltaTime);

            this.CheckViewcone();
		}

		else if (this.task == ActionType.jump)
		{
			this.GetComponent<Rigidbody>().AddForce(Vector3.up * this.jumpPower);
            
			this.task = ActionType.wait;

			this.timer = 0.0f;
		}

		else if (this.task == ActionType.wait)
		{
            this.timer += Time.deltaTime;
		}
        
        else if (this.task == ActionType.attack)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, this.targetPosition, this.movementSpeed * Time.fixedDeltaTime);
        }
	}

	private int ChooseRandomTask()
	{
        int randomTask = Random.Range(0, 3);

		return randomTask;
	}

    private void CheckViewcone()
    {
        bool collision = false;

        for (float angle = -(this.viewConeAngle / 2.0f); angle < (this.viewConeAngle / 2.0f); angle += 2.0f)
        {
            // Ray direciton
            Vector3 direction = Quaternion.Euler(new Vector3(0.0f, angle, 0.0f)) * (this.transform.forward * this.viewConeRange);

            // Debug rendering
            if (this.enableDebugRenderer)
            {
                Debug.DrawRay(this.transform.position, direction);
            }

            // Creating the ray
            Ray ray = new Ray(this.transform.position, direction);
            RaycastHit hitInformation;

            // Saving the hit information
            collision = Physics.Raycast(ray, out hitInformation, this.viewConeRange);

            if (collision)
            {
                // Collided with any wall
                if (hitInformation.collider.tag == "Wall")
                {
                    this.RandomTurn();
                }
                // Collided with any other bot
                else if (hitInformation.collider.tag == "Bot")
                {
                    this.OnCubeVisible(hitInformation);
                }
                // Collided with any player
                else if (hitInformation.collider.tag == "Player")
                {
                    this.OnCubeVisible(hitInformation);
                }

                break;
            }
        }
    }

	private void RandomTurn()
	{
		bool collision = true;

        int loopCounter = 0;
		
		while (collision)
		{
			// Rotating cube using random angle
			float randomAngle = Random.Range(0, 4) * 90.0f;
			
			this.transform.Rotate(Vector3.up, randomAngle);

			// Creating a ray for collision detection
			Ray ray = new Ray(this.transform.position, this.transform.forward);
			RaycastHit hitInformation;
			
			// Using the ray for an other collision detection
			ray = new Ray(this.transform.position, this.transform.forward);
			
			collision = Physics.Raycast(ray, out hitInformation, this.viewConeRange);

            // Incrementing the loop counter
            ++loopCounter;

            // Avoiding infinite loops
            if (loopCounter > 9)
            {
                break;
            }
		}
	}

    private void OnCubeVisible(RaycastHit hitInformation)
    {
        int chance = Random.Range(0, 100);

        // Continue moving
        if (chance < 33)
        {
            this.task = ActionType.move;
        }
        // Turn around
        else if (chance < 60)
        {
            this.RandomTurn();
        }
        // Jump
        else if (chance < 75)
        {
            this.task = ActionType.jump;
        }
        // Attack player
        else if (chance < 90)
        {
            this.targetPosition = hitInformation.collider.transform.position;

            this.task = ActionType.attack;
        }
        // Wait
        else
        {
            this.task = ActionType.wait;
        }
    }
}