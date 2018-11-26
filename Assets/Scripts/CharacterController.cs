using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    CallText collidedObjectScript;
    public int textBoxHeightPercent;
    public int textBoxWidthPercent;
    public Color guiFieldColor;
    char[] typeText;

    //заебала эта помойка
    private int currentPosition = 0;
    public float Delay = 0.1f;
    public string additionalLines;


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
                collidedObjectScript = collidedGameObject.GetComponent<CallText>();
                var splittedString = collidedObjectScript.objectDescription.Split(" "[0]);
                typeText = collidedObjectScript.objectDescription.ToCharArray();
                Debug.Log(typeText);
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

    private void OnGUI()
    { 
        if (collidedObjectScript == null)
        {
            objectDescription = "";
        } else
        {
            objectDescription = collidedObjectScript.objectDescription;
        }
        var temp = StartCoroutine(AnimateText(objectDescription));

        GUI.backgroundColor = guiFieldColor;
        //GUI.Box(new Rect(Screen.height / 100 * textBoxHeightPercent, Screen.width / 100 * textBoxWidthPercent, Screen.width, 200), temp);
    }

    IEnumerator AnimateText(string strComplete)
    {
        int i = 0;
        string str  = "";
        while( i < strComplete.Length)
        {
            strComplete += strComplete[i++];
            yield return new WaitForSeconds(0.5F);
        }
    }
}
