using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball {
  public Vector3 position;

  public float distanceWithAnotherBall(Ball ball){
    return Vector3.Distance(this.position, ball.position);
  }
}