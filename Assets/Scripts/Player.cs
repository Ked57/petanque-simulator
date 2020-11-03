using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player {
  public List<Ball> balls;
  public int score;

  public void throwBall(Ball ball){
    if (this.balls.Length <= 3){
      this.balls.Add(ball);
    }
  }

  public float minimalDistanceOfBallFromAnother(Ball ball){
    float res = null;
    foreach (Ball pBall in this.balls){
      if(res){
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