using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class AnimationManager : MonoBehaviour
{  
    public Animator marioAnimator;


    public void SmallMarioRun() {
        marioAnimator.Play("MarioRun");
    }
    public void LargeMarioRun(){
        marioAnimator.Play("LargeMarioRun");
    }
    public void FireMarioRun() {
        marioAnimator.Play("FireMarioRun");
    }

    public void StopRun() {
        switch(GameManager.instance.marioState) {
            case MarioState.Small:
                marioAnimator.Play("MarioIdle");
                break;
            case MarioState.Large:
                marioAnimator.Play("LargeMarioIdle");
                break;
            case MarioState.FireFlower:
                marioAnimator.Play("FireMarioIdle");
                break;
            default:
                marioAnimator.Play("MarioIdle");
                break;
        }
    }

    public void Jump() {
        switch(GameManager.instance.marioState) {
            case MarioState.Small:
                marioAnimator.Play("MarioJump");
                break;
            case MarioState.Large:
                marioAnimator.Play("LargeMarioJump");
                break;
            case MarioState.FireFlower:
                marioAnimator.Play("FireMarioJump");
                break;
            default:
                marioAnimator.Play("MarioJump");
                break;
        }
    }

    public void Start() {
        GameManager.instance.marioState = MarioState.FireFlower;
        Invoke("Jump",1);
        
    }
    
}
