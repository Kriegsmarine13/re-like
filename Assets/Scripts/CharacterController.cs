using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    GameObject gameObject;
    float speed = 3.0f;
    //bool shootingMode = false;
    public int shootingRange = 10;
    public float pushBack = 1.4f;
    public HandgunScript handgun;
    public CallText description;
    private bool interactionState = false;
    private Collision collidedObject;
    private GameObject collidedGameObject;
    bool allowMovement = true;
    public bool allowCustomMovementInput = true;
    private bool allowMovementForward = true;
    private bool shootingMode = false;
    RaycastHit hit;
    public float collisionCheckFront = 1.2f;
    private string objectDescription;

    // Use this for initialization
    void Start()
    {
        Debug.Log(handgun);
    }
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        //Передвижение
        
        //Если передвижение контролируется этим скриптом
        if(allowCustomMovementInput)
        {
            //Если нет препятствий впереди
            if (allowMovementForward)
            { 
                //Двигаемся
                transform.Translate(0, 0, z);
            }
            //Вращение в стороны доступно вне зависимости от препятствий с какой-либо из сторон
            transform.Rotate(0, x, 0);
        }

        var weapon = GameObject.FindGameObjectWithTag("Weapon");

        //Shoot mode ready
        if (Input.GetKeyDown("z"))
        {
            Debug.Log("Shooting mode");
            shootingMode = true;
            speed = 0f;
            weapon.transform.Rotate(-45, 0, 0);
        }

        //Стрельба (только при нажатии на прицеливание
        if (shootingMode && Input.GetKeyDown("c"))
        {
            handgun.Shoot();
        }

        //Стрельба вверх и вниз
        if(Input.GetKey("z") && Input.GetKeyDown(KeyCode.DownArrow))
        {
            weapon.transform.Rotate(45, 0, 0);
        }
        if(Input.GetKey("z") && Input.GetKeyUp(KeyCode.DownArrow))
        {
            weapon.transform.Rotate(-45, 0, 0);
        }

        if (Input.GetKey("z") && Input.GetKeyDown(KeyCode.UpArrow))
        {
            weapon.transform.Rotate(-45, 0, 0);
        }
        if (Input.GetKey("z") && Input.GetKeyUp(KeyCode.UpArrow))
        {
            weapon.transform.Rotate(45, 0, 0);
        }

        if (Input.GetKeyUp("z"))
        {
            shootingMode = false;
            speed = 3.0f;
            weapon.transform.Rotate(45, 0, 0);
        }

        if (interactionState)
        {
            if (Input.GetKeyDown("c"))
            {
                //Debug.Log("Interacing with " + collidedObject);
                Debug.Log("Interacting with " + collidedGameObject);
                //var description = new CallText();
                //var getText = description.objectDescription;
                description.RenderText();
            }
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, forward, out hit, collisionCheckFront))
        {
            interactionState = true;
            allowMovementForward = false;
            collidedGameObject = hit.collider.gameObject;
        } else {
            interactionState = false;
            allowMovementForward = true;
        }
        Debug.DrawRay(transform.position, forward * collisionCheckFront, Color.yellow);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Interaction
        interactionState = true;
        collidedObject = collision;
        Debug.Log("Interaction State active!");
    }


    //void RenderText()
    //{
    //    var textArea = new Rect(0, 0, Screen.width, Screen.height);
    //    GUI.Label(textArea, objectDescription);
    //}
}
