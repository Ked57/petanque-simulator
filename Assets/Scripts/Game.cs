using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game {
  public Player playerOne;
  public Player playerTwo;
  public Ball miniBall;
  public int roundNumber;
  public bool canBind;

  public Game(){
    this.canBind = true;
  }

  public void initGame(){
    this.playerOne.score = 0;
    this.playerTwo.score = 0;
    this.roundNumber = 0;
  }

  public void throwMiniBall(Ball miniBall){
    this.miniBall = miniBall;
  }

  public void throwPlayerBall(Player player, Ball ball){
    this.player.throwBall(ball);
  }

  public void roundStart() {
    this.roundNumber ++;
  }

  public void roundFinish() {
    Player winner = whichPlayerWonTheRound();
    winner.score = winner.score + howManyScoreRoundWinnerMade(winner);
    playerOne.balls = new List<Ball>();
    playerTwo.balls = new List<Ball>();
  }

  public Player whichPlayerWonTheRound(){
    float playerOneDistance = this.playerOne.minimalDistanceOfBallFromAnother(this.miniBall);
    float playerTwoDistance = this.playerTwo.minimalDistanceOfBallFromAnother(this.miniBall);
    return playerOneDistance > playerTwoDistance ? playerTwo : playerOne;
  }

  public int howManyScoreRoundWinnerMade(Player roundWinner){
    int roundScore = 0;
    if(roundWinner.Equals(this.playerOne)){
      float playerTwoDistance = this.playerTwo.minimalDistanceOfBallFromAnother(this.miniBall);
      foreach (Ball ball in roundWinner.balls){
        if( ball.distanceWithAnotherBall(this.miniBall) < playerTwoDistance){
          roundScore ++;
        }
      }
    }else{
      float playerOneDistance = this.playerOne.minimalDistanceOfBallFromAnother(this.miniBall);
      foreach (Ball ball in roundWinner.balls){
        if( ball.distanceWithAnotherBall(this.miniBall) < playerOneDistance){
          roundScore ++;
        }
      }
    }
    return roundScore;
  }
}