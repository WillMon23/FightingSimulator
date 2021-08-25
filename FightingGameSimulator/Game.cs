using System;
using System.Collections.Generic;
using System.Text;

namespace FightingGameSimulator
{
    class Game
    {
        public struct Monster
        {
            public string name;
            public float health;
            public float attack;
            public float defense;
        }

        Monster monster1;

        Monster monster2;


        // Monster 1
        string monster1Name = "Wumpus";
        float monster1Attack = 10;
        float monster1Defense = 5;
        float monster1Health = 20;

        





        // Monster 2 
        string monster2Name = "Thwompus";
        float monster2Attack = 15;
        float monster2Defense = 10;
        float monster2Health = 15;

        //float CalculateDamage(float attack, float defense)
        //{
        //    float damage = attack - defense;
        //    if (damage <= 0)
        //        damage = 0;
        //    return damage;

        //}

        //Calculates Damage Done 
        float CalculateDamage(Monster monster)
        {
            float damage = monster.attack - monster.defense;
            if (damage <= 0)
                damage = 0;
            return damage;

        }

       // void PrintStats(string name, float attack,float defense, float health)
       // {
       //    Console.WriteLine("Name: " + name +
       //         "\nAttack: " + attack +
       //         "\nDefence: " + defense +
       //         "\nHealth: " + health);
       // }

        void PrintStatStruck(Monster monster)
        {
            Console.WriteLine("Name: " + monster.name +
                "\nAttack: " + monster.attack +
                "\nDefence: " + monster.defense +
                "\nHealth: " + monster.health);
        }
        public void Run()
        {
            //Monster 1 
            monster1.name = "Wumpus";
            monster1.health = 20.0f;
            monster1.defense = 5.0f;
            monster1.attack = 15.0f;

            //Monster 2 
            monster2.name = "Thwompus";
            monster2.health = 15.0f;
            monster2.defense = 10.0f;
            monster2.attack = 15.0f;

            //Prints Monster 1 Stats 
            PrintStatStruck(monster1);
            //prints Monster 2 Stats 
            PrintStatStruck(monster2);

            Console.ReadKey();
            Console.Clear();

            //Monster 1 Attacks Monster 2
            float damagetaken = CalculateDamage(monster1);
            monster1.health -= damagetaken;
            Console.WriteLine(monster1Name + " Has Taken " + damagetaken + " Damage" );

            // Damage Calculation Between Monster 1 Attacking Monster 2  
            damagetaken = CalculateDamage(monster2);
            monster2.health -= damagetaken;
            Console.WriteLine(monster2Name + " Has Taken " + damagetaken + " Damage");

            Console.ReadKey();
            Console.Clear();

            //Monster 1 Attacks Monster 2
            //float damagetaken = CalculateDamage(monster1Attack, monster2Defense);
            //monster2Health -= damagetaken;
            //Console.WriteLine(monster1Name + " Has Taken " + damagetaken + " Damage");

            // Damage Calculation Between Monster 1 Attacking Monster 2  
            //damagetaken = CalculateDamage(monster2Attack, monster1Defense);
            //monster2Health -= damagetaken;



            

            //Prints Monster 1 Stats 
            //PrintStats(monster1Name, monster1Attack, monster1Defense, monster1Health);
            //prints Monster 2 Stats 
            //PrintStats(monster2Name, monster2Attack, monster2Defense, monster2Health);

            //Prints Monster 1 Stats 
            PrintStatStruck(monster1);
            //prints Monster 2 Stats 
            PrintStatStruck(monster2);
            Console.ReadKey();
        }
    }
}
