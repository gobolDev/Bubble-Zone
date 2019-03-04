using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
/// <summary>
/// Handles Players Movement system. This script is attached to Player.
/// </summary>
public class Move : MonoBehaviour
{
    private SpriteRenderer _sprite;                 // Handler to attached SpriteRenderer of this gameObject.
    private Rigidbody2D _rigid;                     // Handler to attached Rigidbody of this gameObject.
    private int speed = 6;                          // Give additional push when player moves.
    private bool leftGo, rightGo;                   // Handles Button movement.
    public GameObject joystickPanel, buttonsPanel;  // Control Panels.

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();

        if (SettingsCtrl.instance.data.isJoystick)  // Sets the appropriate controls on the Start.
        {
            joystickPanel.SetActive(true);
            buttonsPanel.SetActive(false);
        }
        else
        {
            buttonsPanel.SetActive(true);
            joystickPanel.SetActive(false);
        }
    }

    private void Update()
    {   // This is just for the PC movement!!!!!
        float move = Input.GetAxis("Horizontal");    // Using Unity Standard Assets library. Move value is min: 0 - max: 1.
        _rigid.velocity = new Vector2(move * speed, _rigid.velocity.y);     // Sets new X velocity.
    }

    void FixedUpdate()
    {
        if (SettingsCtrl.instance.data.isJoystick)  // Sets the Player controls based on isJoystick. 
        {
            JoystickMovement(); // Moves the player based on Joystick.
        }
        else
        {
            ButtonsMovement();  // Moves the player based on Buttons.
        }
    }
    #region Joystick Movement Code
    void JoystickMovement()     // Called if Joystick is enabled.
    {
        float move = CrossPlatformInputManager.GetAxisRaw("Horizontal");    // Using Unity Standard Assets library. Move value is min: 0 - max: 1.
        _rigid.velocity = new Vector2(move * speed, _rigid.velocity.y);     // Sets new X velocity.

        if (move > 0)       // If move is greater then 0.
        {
            Flip(true);     // Flips the player to right side.
        }
        else if (move < 0)  // If move is less then 0.
        {
            Flip(false);    // Flips the player to left side.
        }
    }
    #endregion
    #region Button Movement Code
    private void ButtonsMovement()  // Called is isJoystick is disabled.
    {
        if (leftGo)     // If the Left Button is pressed.
        {
            MoveHorizontal(-speed); // Moves the player to negative direction.
            Flip(false);            // Flips the player to Left Side.
        }
        if (rightGo)    // If the Right Button is pressed.
        {
            MoveHorizontal(speed);  // Moves the player to positive direction.
            Flip(true);             // Flips the player to Right Side.
        }
    }

    public void MoveHorizontal( float speed)    // Handles Left and Right Button movement.
    {
        _rigid.velocity = new Vector2(speed, _rigid.velocity.y);    // Sets the X axis velocity to speed = 6.
    }

    public void ButtonMovementLeft()    // Called when Left Button is pressed.
    {
       leftGo = true;   // Sets leftGo from false to true.
    }

    public void ButtonMovementRight()   // Called when Right Button is pressed.
    {
        rightGo = true; // Sets rightGo from false to true.
    }

    public void ButtonMovementStop()    // Called after Left or Right Button was pressed.
    {
        rightGo = false;    // Sets rightGo from true to false.
        leftGo = false;     // Sets rightGo from true to false.

        _rigid.velocity = new Vector2(0, _rigid.velocity.y);    // Disables player further movement on X axis.
    }
    #endregion

    void Flip(bool faceRight)   // Used for Fliping Player Sprite according to players movement.
    {
        if (faceRight)  // Checks the faceRight condition.
        {
            _sprite.flipX = true;   // Sets the FlipX to true, flips player to right side.
        }
        else
        {
            _sprite.flipX = false;  // Sets the FlipX to false.
        }
    }

    void OnCollisionEnter2D(Collision2D collision)  // Called on other collision.
    {
        if(collision.gameObject.tag == "Enemies")   // If other collision is Enemes.
        {
            GameCtrl.instance.UpdateLife(1);        // Reduce life for 1.  
        }
    }
}
