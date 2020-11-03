using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game {
  public Player playerOne;
  public Player playerTwo;
  public Player currentPlayer;
  public Ball miniBall;
  public int roundNumber;

  public Game(){
    this.playerOne = new Player();
    this.playerTwo = new Player();
    this.playerOne.score = 0;
    this.playerTwo.score = 0;
    this.roundNumber = 0;
    this.currentPlayer = this.playerOne;
  }


  public void currentBallIsStopped() {
    if(this.whichPlayerWonTheRound().Equals(this.currentPlayer)) {
      if(this.currentPlayer.Equals(this.playerOne)) {
        this.currentPlayer = this.playerTwo;
      }else {
        this.currentPlayer = this.playerOne;
      }
    }
  }
  public void onShoot(GameObject ball) {
    this.currentPlayer.throwBall(new Ball(ball));
  }

  public bool canShoot() {
    return this.currentPlayer.canShoot();
  }

  public void throwMiniBall(Ball miniBall){
    this.miniBall = miniBall;
  }

  public void throwPlayerBall(Player player, Ball ball){
    player.throwBall(ball);
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