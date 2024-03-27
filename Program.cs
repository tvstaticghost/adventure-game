using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerInformation newPlayer = new PlayerInformation(GetPlayerName(), GetPlayerClass());
            newPlayer.ViewPlayerInfo();
            PlayerStats newPlayerStats = ChooseStats(newPlayer.GetClass());
            newPlayerStats.PrintStats();
            newPlayer.LevelUp();
            newPlayer.ViewPlayerInfo();
        }

        static string GetPlayerName()
        {
            Console.WriteLine("Hello. What your name, adventurer?");
            string playerName = Console.ReadLine();
            while (playerName == "")
            {
                if (playerName == "")
                {
                    Console.WriteLine("Please enter your name");
                }
                else
                {
                    break;
                }
                playerName = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {playerName}");
            return playerName;
        }

        static string GetPlayerClass()
        {
            string playerClass;

            Console.WriteLine($"Hello, adventurer. Please choose a class");
            Console.WriteLine($"Ranger, Warrior, or Mage");
            playerClass = Console.ReadLine();

            while (playerClass.ToLower() != "warrior" || playerClass.ToLower() != "mage" || playerClass.ToLower() != "ranger")
            {
                if (playerClass.ToLower() == "mage" || playerClass.ToLower() == "warrior" || playerClass.ToLower() == "ranger")
                {
                    Console.WriteLine($"Wonderful! You will make an excellent {playerClass}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please chose Ranger, Mage, or Warrior");
                    playerClass = Console.ReadLine();
                }
            }
            return playerClass.ToLower();
        }

        static PlayerStats ChooseStats(string playerClass)
        {
            playerClass = playerClass.ToLower();

            if (playerClass == "mage")
            {
                return new PlayerStats(10, 3, 4, 13, 17, 15);
            }
            else if (playerClass == "warrior")
            {
                return new PlayerStats(15, 17, 13, 10, 3, 4);
            }
            else
            {
                return new PlayerStats(13, 10, 15, 17, 4, 3);
            }
        }

        //establish player inventory
        class Inventory
        {
            private List<string> playerInventory;

            public Inventory(string startingItem)
            {
                playerInventory = new List<string>();
                playerInventory.Add(startingItem);
            }

            public void AddItem(string item)
            {
                playerInventory.Add(item);
            }

            public void Get_Inventory()
            {
                Console.WriteLine("Inventory:");
                foreach (string item in playerInventory)
                {
                    Console.WriteLine(item);
                }
            }
        }

        //Establish player information
        class PlayerInformation
        {
            private string playerName;
            private string playerClass;
            private string playerSubClass;
            private int playerLevel;

            public PlayerInformation(string playerName, string playerClass)
            {
                this.playerName = playerName;
                this.playerClass = playerClass;
                this.playerSubClass = "n/a";
                this.playerLevel = 1;
            }

            public string GetClass()
            {
                return this.playerClass;
            }

            public void LevelUp()
            {
                this.playerLevel++;
                Console.WriteLine($"Congradulations! You have leveled up! You are now level {this.playerLevel}");
            }

            public void ViewPlayerInfo()
            {
                Console.WriteLine("----------");
                Console.WriteLine($"Name: {this.playerName}\nClass: {this.playerClass}\nSubclass: {this.playerSubClass}\nLevel: {this.playerLevel}");
                Console.WriteLine("----------");
            }
        }

        //Establish a stat spread
        class PlayerStats
        {
            private int health;
            private int strength;
            private int endurance;
            private int dexterity;
            private int intelligence;
            private int attunement;
            private int currentHealth;

            public PlayerStats(int health, int strength, int endurance, int dexterity, int intelligence, int attunement)
            {
                this.health = health;
                this.strength = strength;
                this.endurance = endurance;
                this.dexterity = dexterity;
                this.intelligence = intelligence;
                this.attunement = attunement;
                this.currentHealth = health;
            }

            public void LevelUp(string skill)
            {
                if (skill == "health")
                {
                    this.health++;
                }
                else if (skill == "strength")
                {
                    this.strength++;
                }
                else if (skill == "endurance")
                {
                    this.endurance++;
                }
                else if (skill == "dexterity")
                {
                    this.dexterity++;
                }
                else if (skill == "intelligence")
                {
                    this.intelligence++;
                }
                else
                {
                    this.attunement++;
                }
            }

            public string CurrentHealth()
            {
                return $"HP: {this.currentHealth}/{this.health}";
            }

            public void PrintStats()
            {
                Console.WriteLine("----------");
                Console.WriteLine($"Health: {this.health}");
                Console.WriteLine($"Strength: {this.strength}");
                Console.WriteLine($"Endurance: {this.endurance}");
                Console.WriteLine($"Dexterity: {this.dexterity}");
                Console.WriteLine($"Intelligence: {this.intelligence}");
                Console.WriteLine($"Attunement: {this.attunement}");
                Console.WriteLine("----------");
            }
        }
    }
}