using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject ballPrefab;
    private GameObject ball;
    public float power;
    public float powerDiff = 0.1f;
    public float rotationSpeed;

    Vector3 currentPosition;
    public float angle = 0.1f;
    public float angleDiff = 0.4f;
    public float height = 0.1f;
    public float heightDiff = 1.0f;

    public Game game;


    void Start()
    {
        currentPosition = transform.position;
        predict();
    }

    public Vector3 calculateForce(){
        return new Vector3((transform.right * angle).x, (transform.up * height).y, (transform.forward * power).z);
    }

    void shoot(GameObject ball){
        ball.GetComponent<Rigidbody>().useGravity = true;
        print(calculateForce());
        ball.GetComponent<Rigidbody>().AddForce(calculateForce(), ForceMode.Impulse);
    }

    void Update(){
        float vertical = Input.GetAxis ("Vertical");
        float Horizontal = Input.GetAxis ("Horizontal");
        
        if ( !ball ) {
            ball = Instantiate(ballPrefab, firePoint.transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody>().useGravity = false;
        }
        if (game.canBind){
            keyBinding();
        }
    }

    void keyBinding(){
        if(Input.GetKeyUp(KeyCode.Space)){
            shoot(ball);
            ball = null;
        }

        if(Input.GetAxis("Mouse Y")<0){
            //Code for action on mouse moving down
            print("Mouse moved down");
            if (power > 1){
                power = power - powerDiff;
                predict();
            }
        }

        if(Input.GetAxis("Mouse Y")>0){
            //Code for action on mouse moving up
            print("Mouse moved up");
            if (power < 20){
                power = power + powerDiff;
                predict();
            }
        }

        if(Input.GetKeyUp(KeyCode.D)){
            print("Key up D");
            angle = angle+angleDiff;
            predict();
        }

        if(Input.GetKeyUp(KeyCode.Q)){
            print("Key up Q");
            angle = angle-angleDiff;
            predict();
        }

        if(Input.GetKeyUp(KeyCode.Z)){
            print("Key up Z");
            height = height+heightDiff;
            predict();
        }

        if(Input.GetKeyUp(KeyCode.S)){
            print("Key up S");
            height = height-heightDiff;
            predict();
        }
    }

    void predict(){
        PredictionManager.instance.predict(ballPrefab, firePoint.transform.position, calculateForce());
    }
}
