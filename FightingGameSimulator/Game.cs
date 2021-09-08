using System;
using System.Collections.Generic;
using System.Text;

namespace FightingGameSimulator
{       public struct Monster
    {
        public string name;
        public float health;
        public float attack;
        public float defense;
    }
    class Game
    {

        //Monster 1 
        Monster wumpus;
        //Monster 2 
        Monster thwompus;
        //Monste 3 
        Monster backUpWumpus;
        //Monste 4
        Monster unclePhil;

        bool gameOver = false;
        Monster currentMonster1;
        Monster currentMonster2;
        int currentNumberIndex = 0;
        int currentScene = 0;


        //Calculates Damage Done 
        float CalculateDamage(Monster monster)
        {
            float damage = monster.attack - monster.defense;
            if (damage <= 0)
                damage = 0;
            return damage;

        }
      
        // Prints Monster Stats 
        void PrintStatStruck(Monster monster)
        {
            Console.WriteLine("Name: " + monster.name +
                "\nHealth: " + monster.health +
                "\nDefence: " + monster.defense +
                "\nAttack: " + monster.attack);
            Console.ReadKey();
        }

        // Dmaage Calculations Between Enemies and there Defence 
        float CalculateDamage(Monster attack, Monster defender )
        {
            float damage = attack.attack - defender.defense;
            if (damage <= 0)
                damage = 0;
            return damage;
        }

        // Simulats The Fighting Encounter
        float Fight(Monster attacker, ref Monster defender)
        {
            float damagetaken = CalculateDamage(attacker, defender);
            defender.health -= damagetaken;
            return damagetaken;
        }

        string StartBattle (ref Monster monster1, ref Monster monster2)
        {
            string matchResult = "No Contest";
            while (monster1.health > 0 && monster2.health > 0)
            {

                //Prints Monster 1 Stats 
                PrintStatStruck(monster1);
                //prints Monster 2 Stats 
                PrintStatStruck(monster2);

                //Monster 1 Attacks Monster 2
                float damagetaken = Fight(monster1, ref monster2);
                monster1.health -= damagetaken;

                // Displaying Damage taken to Monster1
                Console.WriteLine(monster1.name + " Has Taken " + monster1.health + " Damage");

                // Damage Calculation Between Monster 1 Attacking Monster 2  
                damagetaken = Fight(monster2, ref monster1);
                monster2.health -= damagetaken;

                // Displaying Damage taken to Monster2
                Console.WriteLine(monster2.name + " Has Taken " + monster2.health + " Damage");


                PrintStatStruck(monster1);
                //prints Monster 2 Stats 
                PrintStatStruck(monster2);
                Console.ReadKey(true);

            }

            if (monster1.health <= 0 && monster2.health <= 0)
                matchResult = "Draw";

            else if (monster1.health > 0)
                matchResult = monster1.name;

            else if (monster2.health > 0)
                matchResult = monster2.name;
            
                
            return matchResult;

        }
        void Start()
        {

            wumpus.name = "Wumpus";
            wumpus.health = 20.0f;
            wumpus.defense = 5.0f;
            wumpus.attack = 15.0f;


            thwompus.name = "Thwompus";
            thwompus.health = 15.0f;
            thwompus.defense = 10.0f;
            thwompus.attack = 15.0f;


            backUpWumpus.name = "BackUp Wumpus";
            backUpWumpus.health = 3.0f;
            backUpWumpus.defense = 5.0f;
            backUpWumpus.attack = 25.6f;


            unclePhil.name = "Uncle Phil";
            unclePhil.health = 1.0f;
            unclePhil.defense = 10.0f;
            unclePhil.attack = 100f;

            RestartCurrentMonsters();
        }

        void RestartCurrentMonsters()
        {
            currentNumberIndex = 0;
            //Set starting figters 
            currentMonster1 = GetMonster(currentNumberIndex);
            currentNumberIndex++;
            currentMonster2 = GetMonster(currentNumberIndex);
        }

        /// <summary>
        /// A Function that mimmics a List 
        /// cycling through the ammount of monster within hat list 
        /// Once the numaration runs through the index it then
        /// retuens the monster in that index
        /// </summary>
        /// <param name="monsterIndex"> Location of said needed Moster </param>
        /// <returns></returns>
        Monster GetMonster(int monsterIndex)
        {
            Monster monster;
            monster.name = "None";
            monster.attack = 1f;
            monster.defense = 1f;
            monster.health = 1f;

            if(monsterIndex == 0)
            {
                monster = unclePhil;
            }
            else if (monsterIndex == 1)
            {
                monster = backUpWumpus;
            }
            else if (monsterIndex == 2)
            {
                monster = wumpus;
            }
            else if (monsterIndex == 3)
            {
                monster = thwompus;
            }
            return monster;
        }

        /// <summary>
        /// Change one of the current figters to be the next in the list
        /// if it has died. Ends rhe game if all figters in the list have been used.
        /// </summary>
        void UpdateCurrentMonsters()
        {   
            // If monster 1 died
            if (currentMonster1.health <= 0)
            {

                // increment the current monster index and swap out the monster
                currentNumberIndex++;
                currentMonster1 = GetMonster(currentNumberIndex);
            }
            // If monster 2 died 
            if (currentMonster2.health <= 0)
            {
                // increment the current monster index and swap out the monster
                currentNumberIndex++;
                currentMonster2 = GetMonster(currentNumberIndex);
            }
            // If its not ether of them or the index went out of bounds  
            if (currentMonster2.name == "None" || currentMonster1.name == "None" && currentNumberIndex >= 4)
            {
                // ends game 

                currentScene = 2;
            }
            
        }

        void UpdateCurrentSceen()
        {

            switch (currentScene)
            {
                case 0:
                    DisplayMainMenu();
                    break;

                case 1:
                    Battle();
                    UpdateCurrentMonsters();
                    Console.ReadKey();
                    break;

                case 2:
                    DisplayRestartMenu();
                    break;

                default:
                    Console.WriteLine("Invalid scene index");
                    break;
                    

            } 
            /*
            if (currentScene == 0)
                DisplayMainMenu();

            else if (currentScene == 1)
            {
                Battle();
                UpdateCurrentMonsters();
                Console.ReadKey(true);
            }

            else if (currentScene == 2)
                DisplayRestartMenu(); */
        }


        /// <summary>
        /// Checkes if user wants to end or start over 
        /// </summary>
        void DisplayRestartMenu()
        {
            // Sets the users creats the end screen display to grab the users choice
            int choice = GetInput("Simulation over. Would you like to play again?", "Yes", "No");

            // checks if the user chooces 1... 
            if (choice == 1)
            {
                /// ...Starts the all Over and sets the currentScene to 0
                RestartCurrentMonsters();
                currentScene = 0;
            }
            // checks if the user chooses 2...
            else if (choice == 2)
                //Ends the Game 
                gameOver = true;
        }

        /// <summary>
        /// Displays the starting menu. Gives the user the option to start or
        /// exit the simulation 
        /// </summary>
        void DisplayMainMenu()
        {
            //Gets users choice
            int choice = GetInput("Welcome to Monster Fight Simulator and Uncle Phill", "Start Simulation", "Quit Application");

            //Wither the choice is to start the simulation 
            if (choice == 1)
            {
                currentScene = 1;
            }

            //Wither the choice is to end the Simulation
            else if (choice == 2)
            {
                gameOver = true;
            }
        }

        /// <summary>
        /// Gets users input based on some decision 
        /// </summary>
        /// <param name="description">The Context of the deciosion</param>
        /// <param name="option1">sets the first writen option for the user</param>
        /// <param name="option2">sets the second writen option for the user</param>
        /// <param name="pauseInvaled"> if true user needs to press a key to continue</param>
        /// <returns></returns>
        int GetInput(string description, string option1, string option2, bool pauseInvaled = false)
        {
            // sets the context for the user & there choices 
            Console.WriteLine(description);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);

            //Gets the input
            string input = Console.ReadLine();
            int chocie = 0;

            // if user types 1 
            if (input == "1")
                chocie = 1;

            // if user types 2 
            else if (input == "2")
                chocie = 2;

            // Makes sure user is not typing off screen response 
            else
            {
                // Prints out invaled input
                Console.WriteLine("Invaled Input");
                
                // checks to see if true 
                if (pauseInvaled)
                    // makes user type a Key to continue 
                  Console.ReadKey(true);
            }

            return chocie;

        }
        
        /// <summary>
        /// Simulates one turn in the current monster fight
        /// </summary>
        void Battle()
        {
            //Prints Monster 1 Stats 
            PrintStatStruck(currentMonster1);

            //prints Monster 2 Stats 
            PrintStatStruck(currentMonster2);

            //Monster 1 Attacks Monster 2
            float damagetaken = Fight(currentMonster1, ref currentMonster2);
            currentMonster1.health -= damagetaken;
            // Displaying Damage taken to Monster1
            Console.WriteLine(currentMonster1.name + " Has Taken " + currentMonster1.health + " Damage");

            // Damage Calculation Between Monster 1 Attacking Monster 2  
            damagetaken = Fight(currentMonster2, ref currentMonster1);
            currentMonster2.health -= damagetaken;
            // Displaying Damage taken to Monster2
            Console.WriteLine(currentMonster2.name + " Has Taken " + currentMonster2.health + " Damage");

            string resault = StartBattle(ref currentMonster1, ref currentMonster2);

            if (resault == "Draw")
                Console.WriteLine(resault + " Game");
            else if (resault == "No Contest")
                Console.WriteLine(resault);
            else
                Console.WriteLine(resault + " Is The Winner");

            //prints Monster 1 Stats
            PrintStatStruck(currentMonster1);
            //prints Monster 2 Stats 
            PrintStatStruck(currentMonster2);


            Console.ReadKey();
        }

        /// <summary>
        /// Called Every Game Loop
        /// </summary>
        void Update()
        {
            UpdateCurrentSceen();
            Console.Clear();
        }

        void End()
        {
            Console.WriteLine("Good Bye Fran");
        }
        public void Run()
        {
            Start();

            while (!gameOver)
                Update();

            End();
        }
    }
}
