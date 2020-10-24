# Unity
### How to make a Video Game -11 Videos
Link: https://www.youtube.com/watch?v=9ZEu_I-ido4&index=3&list=PLPV2KyIb3jR53Jce9hP7G5xC4O9AgnOuL
![](doc/1.PNG)
# Gatting Started with Unity Scripting প্লেয়ার এর কোড 
``` C#
public Rigidbody rb; 
// This is reffernce to called Rididbody which have to set to instance
void Start () {
        Debug.Log("What you want to expose on console panel!");
        rb.useGravity = false;
 rb.AddForce(0, 0, 200*Time.deltaTime); 
 // Change Mass and Gravity and overs the changes 
}
```
# How to Move a object automatically to Z Axis প্লেয়ার এর কোড
``` C#
public Rigidbody rb; //Player Rigidbody
public float forwardForce; //value may be 1000
    
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
```
NB: 	to stop sliding, Add Physics Metrials and set Dynamics and Static Friction to Zero
FixedUpdate : Mass with Physics
ViewCube positon will be X at right and side and Y at top for both 3d and 2d

Different Panel Name
Scene view | Game view | Hierarchy | Project | Inspector
![](doc/2.PNG)
# Get Input Key Control প্লেয়ার এর কোড
``` C#
public Rigidbody rb;
public float forwardForce=2000;
public float sideForce=100;
    
void FixedUpdate () {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);

        }
}
```
# Camera Roll, Follow the Player ক্যামেরা এর কোড
``` C#
public Vector3 offset; //value may be 0,3.25,-8 where camera position 0,4,-8 rotation 16,0,0 and Player position 0,0.75,0
       public Transform PlayerPosition; //Player have to set as instance
	
	void Update () {
        transform.position = PlayerPosition.position+ offset;
	}
```
# Clash of Particles or Element in Unity প্লেয়ার এর কোড

//First we have to add some Obstacle and add a tag of it and rename it Obstacle 
``` C#
using UnityEngine;

public MovePlayer movment; //Player movement script


	public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name/tag == "Obstracle")
        {
            movment.enabled = false; //Player movement stop here
     //GetComponent<MovePlayer>().enabled = false;
            Debug.Log(collisionInfo.collider.name/tag);
        }
        
    }
```
![](doc/3.PNG)
# Score in Unity ইউআই টেক্সট কোড

Create new UI->Text (Canvas->Text(rename it : Score))
Position the Text using 2D view and Select with Screen Size, Match Width and Height, Canvas->Match ->1
 Add a Script name it ScoreCount and Add NameSpace UI
``` C#
using UnityEngine;
using UnityEngine.UI;

public class ScroreCount : MonoBehaviour {

    public Text socreText; // Assign Text (Script)  of Score
    public Transform PlayerTransform; // Assign Player of the game
	void Update () {
        socreText.text = PlayerTransform.position.z.ToString("0");
	}
}
```
# GameManager(GameObject) গেইম ম্যানেজার কোড
Create Create Empty for control our Game, rename as GameManager
Add Script at GameManager named it GameManager.cs
Add an End Class with the following code
``` C#
bool endGame = false;
// Code:01
public GameObject panel; 
	public void End()
    {
        if (endGame == false)
        {
            endGame = true;
            Debug.Log("End Game"+endGame);
        }
           }

public void LevelComplete()  //for future us in EndTrigger Script, Don’t Read Now
    {
        Debug.Log("Level Complete");
 	
// Code:01
panel.SetActive(true); 
movment.enabled = false;
    } 

Add code at Player Collision Scripts 
FindObjectOfType<GameManager>().End(); 
// This code is similar to 
//Public GameManager GM;
// Gm.End(); 
//it’s not a good Practice 

Add Similar code at PlayerMove Scrips: 

if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().End();
        } 
```
# Scene Management গেইম ম্যানেজার কোড

//Just add a NameSpace SceneManagement to Access Scene Manager
``` C#
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    bool endGame = false;
	public void End()
    {
        if (endGame == false)
        {
            endGame = true;
            Debug.Log("End Game"+endGame);
            Invoke("Restart", 2f);
        }
       }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
```
# Lavel Complete গেইম ম্যানেজার কোড, End Qube দ্বারা কল হবে
Add a Cube, Place it where you want to stop the game, make it invisible (Uncheck the Mesh Render) rename it to End, add icon to see. Checked Is Trigger option, add a script, named it EndTrigger.
``` C#
public GameManager GM;
	public void OnTriggerEnter()
    {
        GM.LevelComplete();
    }
}
```
>Show Screen(Panel) after Level Complete

To Display a Screen after level complete, we need add a panel may be with some text, animation etc.
To do this go to Hierarchy RC, UI->Panel (to see this panel go to Scene->2D Mode, press F and the setup Source Image to none, reduce alpha to solid color), Now add text under Panel, Rename the Panel name, say LevelComplet. Set Panel Activation False. Add these following code under GameManager->LevelComple Class-> Code:01
Note: When we use Scene Management the Lighting will auto medically changed, to fix this:  Lighting->Debug Settings-> Unchecked Auto Generate.
# Gave Over গেইম ম্যানেজার কোড, 
Create new UI->Text (Canvas->Text(rename it : Gaveover))
Set it Inactive

And add those line of code at  End() class
            
            Gameover.SetActive(true); 
            

# Animation:Show Panel প্যানেলের কোড,

Select Panel (or any Object) goto to Animation Window(Ctrl+6), Create Animation(it will create two file, 1. Animation 2. Animation Setting File), Click on Enable Key Frame Record Mode, Select Key Frame Change Some Properties, Say Color, Alpha etc, Select another point do it again. Now Play the Game the animation will show if Panel is called.
Animation:Add a Event(Load Next Lavel) প্যানেলের কোড,
Select Panel animation, Select a keyframe, press add Event Button, Now you can select a function (Panel Script Public Class) under this event & 
``` C#
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour {
	public void LoadNextLevel () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
```
Stage Creatation
At this First Stage completion, Create all Elements Perhaps: Player, Obstacle, Canvus, End, Main Camera, GameManager etc. so that we can control all element centrally in large. 
Now Duplicate the Scene01 and Rename it 
# Menu With Start/Quit Button প্যানেলের কোড,
Create a new Scene->Create UI->Panel (rename it Menue)->Text(rename it Welcome), Create UI->Button(rename it Start);
Add a Script to Panel sys StartGame, add a public void Class StartNow()
Now we add a button onClick Event, Go to button On Click option, set instance to the Object( here object is Panel where we assign script), now click on no function drop down, it will show StartGame->StartNow() class, assign & write script on it.
``` C#
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	
	public void StartNow() {
        
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
```
Similar for Exit Button on another Panel/Credits on another Scene:
``` C#
using UnityEngine;

public class Credits : MonoBehaviour {

public void QuiteGame () {
        Application.Quit();
        Debug.Log("Quite");
	}
}
```
# Set animation to Avater(Move with arrow key) প্লেয়ারের কোড

First we take a Character and drop it to our scene, add animation to it, create an Animation Controller and attach it to the charter control portion, we drop animation say idle, run, walk at this Animation Controller. 1st animation will set as default.  We need to make transition to 1st to another to play other. Now we can create parameter with different types say Boolean, trigger etc. if we select animation at AC we find a Transition option at inspector we can select parameter here which we can access in script under Animator object. NB: selection an animation->under animations option we can select Loop Time. Has Exit Time is useful to perform control instant.
``` C#
static Animator anim;
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

               
        float translation = Input.GetAxis ("Vertical")*speed;
        float rotation = Input.GetAxis("Horizontal")*rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0,0,translation);
        transform.Rotate(0,rotation,0);

       
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
            Debug.Log("isJumping");
        }
       
        if (translation != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
	}
```
# Create Menu প্যানেলের কোড,
Create a set of button under empty object say Menu, duplicate it create another set of button Say Option
Now select any button say OptionButton in menu set, add two onClick event, one for Menu another for Option, here under gameObject -> SetActive false i.e. unchecked for Menu and Checked for Option sets

# Button Control বাটনের কোড,
Just create a button rename it say Start Game, Now write Start code under a public class any where you wand, add a mouse click event under Button, attach game object where the script is written, now attach the function, under script->Function say StartGame(), similar for Leaft(), Right, Quit(),Exit(),
Audio on Button Press বাটনের কোড,
Checked that audio Listener attached on Main camera, Add an audio on Library, goto Game Object->Audio->Audio Source. Now attach our audio clip to the Audio Source ->AudioClip slot. Now create a add a onClick event and attach Audio Source to GameObject slot, now on Function slot add AudioSource -> PlayOnShot().
Audio on wake যে কোন অবজেক
Add audio Source to any game object, not drag and drop audio to Audio Clop option and chose Play on Awake, Now when game play the music will automatically play.

Rigidbody->Drag Option work for how fast sliding the player
Canvas->Pixel Perfect, for resolution Sharper
Keyboard Shortcut
Shift+Space -> Maximize View
Windos->Lightings->Settings->Fog