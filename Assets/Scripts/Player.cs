using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player {
  public List<Ball> balls = new List<Ball>();
  public int score;

  public bool canShoot() {
    if(balls.Count > 3){
      return false;
    }
    if(balls.Count > 0) {
      return !balls[balls.Count - 1].isMoving();
    }
    return true;
  }
  public void throwBall(Ball ball){
    if (this.canShoot()){
      this.balls.Add(ball);
    }
  }

  public float minimalDistanceOfBallFromAnother(Ball ball){
    float res = -1f;
    foreach (Ball pBall in this.balls){
      if(res < 0f){
        res = pBall.distanceWithAnotherBall(ball);
      } else {
        if (res > pBall.distanceWithAnotherBall(ball)){
          res = pBall.distanceWithAnotherBall(ball);
        }
      }
    }
    return res;
  }
}