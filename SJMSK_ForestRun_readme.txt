ReadMe Forest Run
Team SJMSK

I. Scene: Forest

About: 
You are Alphie, a lost apple-creature in the forest and you must find your way to the safe cabin. Your journey is a dangerous one, as wild animals will try to eat you. You must distract these animals of the forest using food that you find along the path to the objective, and once you make it there, you complete the level. 

II. How to play and what parts of the level to observe technology requirements

To move the character, use the directional pad or the "w", "a'', "s", or "d" keys. The player can jump, and this is executed with the "space" key. The character also could pick up and throw food items. To pick up an item, simply run into it. The item will disappear to indicate you have successfully obtained it. When forest animals approach you, launch the food item to distract the animals. Use the "e" key to throw food. 

As the player collects food items, the player accumulates points. Each item you the player obtains is worth 250 points, and each level cleared is worth 1000 points. 

The objective of the player is to make it to the end of the level. The end of the level is indicated by the objective (cabin, castle, and pyramid) at the opposite end of the level. Animals will chase the player by default and will deal damage with attacks as they draw nearer. The player will die if Alphie receives too much damage. To avoid being attacked, obtain food items, and toss them or eat them. The food will distract the animals, giving you time to flee. The player will change levels once Alphie reaches the cabin.

III. Known problem areas

Jumping: The game jumping mechanic received several comments during playtesting, however the team decided not to change it because it adds a level of progression mastering it. It is an easy command to learn but hard to master.

IV. Manifest

[Note that some of the scripts and assets have been dropped from the final submission because of factors such ameliorations or consensus from the group].

Sami Aji: 

Sami contributed to level design, game concept design, and script design for picking up items, throwing items, and enemy control. He created the character control script and camera scripts. He helped to fix coding bugs throughout many of the scripts and helped to fine-tune assets for better gameplay. He refactored and cleaned code uploaded to the repository and organized team meetings and provided meeting notes. He built the AIStateMachine to handle the different states which an enemy can be in.

Scripts: 
	CameraControlScript
	CameraFollowCharacterScript
	CharacterControlScript
	AIStateMachine
	HandleAttackingState
	HandleChasingState
	HandleDistractedState
	HandleWanderingState

Assets: 
	Player

Stylianos Kalamaras: 

Steve imported the terrain and designed the layout of the levels and game environment. He added trees and water to the game environment. Steve wrote scripts to control weather and player teleportation when switching levels and recorded gameplay footage for the alpha version. 

Scripts:
 	FogController
	LevelEnd
	LevelManager
	TeleportTrigger
	
Assets: 
	Terrain

Josue Chavez: 

Josue designed the various screens and menus such as the pause menu, game over menu, and the wrong-way indicator that informs the player of the correct direction to move within a level. He added the ability within the scripts for enemies to deal out quantifiable damage to the player as well as the player to take damage. He designed a health bar for the player’s damage indicator and the ability to track the player’s score. He also designed the alpha version sound effects. 

	• Added the health bar and operations to restore it
	• Showed the alert when the user went the wrong way
	• Added the in-game menus
	• Made the game audio sound for all the game
	• Made the trailer, gameplay, and other videos
	• Reviewed merge requests
	• Attended all the meetings
	• Supported members for their issues when it comes to git or using C# code
	• Communicated in the chat within a reasonable time


Scripts:
	LevelEnd
	Attackable
	Attacker
	HealthManager
	ScoreManager
	DisableGame
	EnableGame
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

Kevin contributed ideas for the overall game concept; imported the burger asset and the final animal assets and placed the final enemy assets in the game environment; programmed the first iterations of animations and scripts to allow the bear, wolf, and boar assets to interact in the game environment; developed the initial scripts for item picking and throwing, the enemies to be distracted by food, as well as the code for the enemies to chase the player. He designed the initial assets to provide the feature of the player’s game ending when falling into canyons within the game environment. He tested, reviewed, and merged pull requests on the team GitHub repository. He contributed to playtesting by contributing a playtester for the game and authoring a summary of the results of the playtesting efforts. 

Scripts:
	ItemCollector
	Collectible
	EnemyControlScript
 
Assets: 
	Bear
	Wolf
	Boar
	Burger
	DeathZones
	


Moulaye Zein Haidara:

Pre-Alpha: 
Zein took charge of importing the necessary assets for the cat and Pier's houses, ensuring seamless integration into the game environment. Initially, he attempted to create an AI script for the cat - AIpatrol.cs. When faced with implementation challenges, he collaborated effectively with Kevin to adapt his EnemyChasing script, tailoring it to suit the cat's behavior. Sami further enhanced the cat's appearance by fine-tuning its animation and size, ensuring it harmoniously blended with the scene. Zein also integrated teleportation and scoring systems for the houses, relying on NextLevel.cs for teleportation and EndGame.cs for managing game conclusions. Note that the triggers only work if a GameObject has the script InHouseTrigger.cs.

Final submission:
After the alpha, he was charged to handle the lives system after the player fell, initially intended for level 3, but later incorporated to all levels. The lives are stored in the player control script and interacted with in the Respawn collectible script to add live and in the Fall Zone script to subtract them when the player falls in the death zone. He also handled the tutorial portion of the game such as the pause menu “Help” window and the tutorial text that appears when the “Pick Me Up” burger is picked (Tutorial Text script). Finally, he contributed heavily in the design of level 3 to make it more playable after considering suggestions from the playtesters.

Scripts:
	AIpatrol
	Enemy Control Script
	InHouseTrigger
	Next Level
	End Game Trigger
	Fall Zone
	Text Face Camera
	Tutorial Text
	Respawn Collectible
	GameOverMenu
	Character Control Script (two functions)
	GameStarter (few functions)

Assets:
	Lives Collectible
	Tutorial canvas
	Pick me up Burger and coffee with texts.
	WinGame canvas
	GameOver canvas
	Pier_house
	Cat
	Level 3 partial design
	Wrongway Designator
