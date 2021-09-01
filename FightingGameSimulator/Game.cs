﻿using System;
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
        int currentNumberIndex = 1;


        //Calculates Damage Done 
        float CalculateDamage(Monster monster)
        {
            float damage = monster.attack - monster.defense;
            if (damage <= 0)
                damage = 0;
            return damage;

        }

      

        void PrintStatStruck(Monster monster)
        {
            Console.WriteLine("Name: " + monster.name +
                "\nAttack: " + monster.attack +
                "\nDefence: " + monster.defense +
                "\nHealth: " + monster.health);
            Console.ReadKey();
        }

        // Set Monsters To Attack Eachother
        float CalculateDamage(Monster attack, Monster defender )
        {
            return attack.attack - defender.defense;
        }

        float Fight(Monster attacker, ref Monster defender)
        {
            float damagetaken = CalculateDamage(attacker, defender);
            defender.health -= damagetaken;
            return damagetaken;
        }

        string StartBattle (ref Monster monster1, ref Monster monster2)
        {
            string matchResult = "No Contest";
            while (monster1.health < 0 && monster2.health < 0)
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

        void Update()
        {
            Battle();
        }

        Monster GetMonster(int monsterIndex)
        {
            Monster monster;
            monster.name = "None";
            monster.attack = 1f;
            monster.defense = 1f;
            monster.health = 1f;

            if(monsterIndex == 1)
            {
                monster = unclePhil;
            }
            else if (monsterIndex == 2)
            {
                monster = backUpWumpus;
            }
            else if (monsterIndex == 3)
            {
                monster = wumpus;
            }
            else if (monsterIndex == 4)
            {
                monster = thwompus;
            }
            return monster;
        }

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


            PrintStatStruck(currentMonster1);
            //prints Monster 2 Stats 
            PrintStatStruck(currentMonster2);


            Console.ReadKey();
        }

        void UpdateCurrentMonsters()
        {
            
        }

        public void Run()
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
            unclePhil.defense = 0f;
            unclePhil.attack = 1000000000f;


            Console.ReadKey();
            //Console.Clear();


            string resault = StartBattle(ref wumpus, ref thwompus);

            if (resault == "Draw")
                Console.WriteLine(resault + " Game");
            else if (resault == "No Contest")
                Console.WriteLine(resault);
            else
                Console.WriteLine(resault + " Is The Winner");

        }
    }
}
