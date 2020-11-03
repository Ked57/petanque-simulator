using UnityEngine;

public class Ball {
  public GameObject ballObject;
  public Vector3 previousPosition;
  public Vector3 position;

  public Ball(GameObject ballObject) {
    this.ballObject = ballObject;
  }

  public float distanceWithAnotherBall(Ball ball){
    return Vector3.Distance(this.position, ball.position);
  }

  public bool isMoving() {
    return Vector3.Distance(this.position, this.previousPosition) <= 1f;
  }
}