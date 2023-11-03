ReadMe Forest Run
Team SJMSK
I. Scene: Forest




About: 


You are Alphie, a lost apple-creature in the forest and you must find your way to the safe cabin. Your journey is a dangerous one, as wild animals will try to eat you. You must distract these animals of the forest using food that you find along the path to the cabin. Once you make it to the cabin, you complete the level. 


II. How to play and what parts of the level to observe technology
requirements


To move the character, use the directional pad or the "w", "a'', "s", or "d" keys. The player has the ability to jump and this is executed with the "space" key. The character also has the ability to pick up and throw food items. To pick up an item, simply run into it. The item will disappear to indicate you have successfully obtained it. When forest animals approach you, launch the food item to distract the animals. Use the "e" key to throw food. 


As the player collects food items, the player accumulates points. Each item you the player obtains is worth 250 points. 


The objective of the player is to make it to the end of the level. The end of the level is indicated by the cabin at the opposite end of the level. Animals will chase the player by default and will deal damage with attacks as they draw nearer. The player will die if Alphie receives too much damage. To avoid being attacked, obtain food items and toss them. The food will distract the animals, giving you time to flee. The player will change levels once Alphie reaches the cabin. 




III. Known problem areas


The game world needs boundaries to keep the player out of canyons in the game environment. The player has the ability to fall off of the game world. If the player falls into one of the canyons of the game environment, then the player can walk along the bottom of the canyon, to the edge, and then out of the terrain. 




IV. Manifest
Moulaye Zein Haidara:
Zein took charge of importing the necessary assets for the cat and Pier's houses, ensuring seamless integration into the game environment. Initially, he attempted to create an AI script for the cat - AIpatrol.cs. When faced with implementation challenges, he collaborated effectively with Kevin to adapt his EnemyChasing script, tailoring it to suit the cat's behavior. Sami further enhanced the cat's appearance by fine-tuning its animation and size, ensuring it harmoniously blended with the scene. Zein also integrated teleportation and scoring systems for the houses, relying on NextLevel.cs for teleportation and EndGame.cs for managing game conclusions. Note that the triggers only work if a GameObject has the script InHouseTrigger.cs.


Scripts:
AIpatrol
EnemyControlScript
InHouseTrigger
NextLevel
EndGameTrigger


Assets: 
Pier_house
Pier_house 2
Cat


Sami Aji: 
        Sami contributed to level design, game concept design, and script design for picking up items, throwing items, and enemy control. He created the character control script and camera scripts. He helped to fix coding bugs throughout many of the scripts and helped to fine-tune assets for better gameplay. He refactored and cleaned code uploaded to the repository and organized team meetings and provided meeting notes. 


Scripts: 
CameraControlScript
CameraFollowCharacterScript
CharacterControlScript


Assets: 
Player


Stylianos Kalamaras: 
Steve imported the terrain and designed the layout of the levels and game environment. He added trees and water to the game environment. Steve wrote scripts to control weather and player teleportation when switching levels and also recorded gameplay footage for the alpha version. 


Scripts:
         FogController
        LevelEnd
        LevelManager
TeleportTrigger
        
Assets: 
        Terrain


Josue Chavez: 
        Josue designed the various screens and menus such as the pause menu, game over menu, and the wrong-way indicator that informs the player of the correct direction to move within a level. He added the ability within the scripts for enemies to deal out quantifiable damage to the player as well as the player to take damage. He designed a health bar for the player’s damage indicator and the ability to track the player’s score. He also designed the alpha version sound effects. 


Scripts:
        LevelEnd
        Attackable
        Attacker
        HealthManager
        ScoreManager
        DisableGame
        EnableGame
        GameOverMenu
        PauseMenuToggle
 
Assets: 
        PauseMenuCanvas
GameOverCanvas
WrongWayCanvas
WinGameCanvas
HealthManagerGameObj
ScoreManagerGameObj
BackgroundMusic
        EventSystem
        
Kevin Stanford: 
Kevin contributed ideas for the overall game concept, imported food and the bear assets and designed them to interact in the game environment, developed the initial scripts for item picking and throwing, the enemies to be distracted by food, as well as the code for the enemies to chase the player. 


Scripts:
        ItemCollector
        Collectible
        EnemyControlScript
 
Assets: 
        Bear
        Burger
