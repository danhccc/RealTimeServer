using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    Vector2 characterPositionInPercent;
    Vector2 characterVelocityInPercent;

    const float CharacterSpeed = 0.25f;

    float HalfCharacterSpeed = Mathf.Sqrt(CharacterSpeed * CharacterSpeed + CharacterSpeed * CharacterSpeed) * 0.5f;


    void Start()
    {
        NetworkedServerProcessing.SetGameLogic(this);
    }

    void Update()
    {
        characterPositionInPercent += (characterVelocityInPercent * Time.deltaTime);

        Debug.Log(characterPositionInPercent);
    }

    public void UpdateDirectionalInput(int d)
    {
        characterVelocityInPercent = Vector2.zero;

        if (d == KeyboardInputDirections.UPRIGHT)
        {
            characterVelocityInPercent.x = HalfCharacterSpeed;
            characterVelocityInPercent.y = HalfCharacterSpeed;
        }
        else if (d == KeyboardInputDirections.UPLEFT)
        {
            characterVelocityInPercent.x = -HalfCharacterSpeed;
            characterVelocityInPercent.y = HalfCharacterSpeed;
        }
        else if (d == KeyboardInputDirections.DOWNRIGHT)
        {
            characterVelocityInPercent.x = HalfCharacterSpeed;
            characterVelocityInPercent.y = -HalfCharacterSpeed;
        }
        else if (d == KeyboardInputDirections.DOWNLEFT)
        {
            characterVelocityInPercent.x = -HalfCharacterSpeed;
            characterVelocityInPercent.y = -HalfCharacterSpeed;
        }
        else if (d == KeyboardInputDirections.RIGHT)
        {
            characterVelocityInPercent.x = CharacterSpeed;

        }
        else if (d == KeyboardInputDirections.LEFT)
        {
            characterVelocityInPercent.x = -CharacterSpeed;

        }
        else if (d == KeyboardInputDirections.UP)
        {
            characterVelocityInPercent.y = CharacterSpeed;
        }
        else if (d == KeyboardInputDirections.DOWN)
        {
            characterVelocityInPercent.y = -CharacterSpeed;
        }
        else if (d == KeyboardInputDirections.NoPress)
        {
            // Do nothing
        }
    }

}

