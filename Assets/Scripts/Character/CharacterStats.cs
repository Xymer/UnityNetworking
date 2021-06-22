using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CharacterStats
{
    public CharacterStats(int level, int health, int mana, int strength, int dexterity, int intelligence, int vitality)
    {
        Level = level;
        Health = health;
        Mana = mana;
        Strength = strength;
        Dexterity = dexterity;
        Intelligence = intelligence;
        Vitality = vitality;
    }
    int Level;
    int Health;
    int Mana;
    int Strength;
    int Dexterity;
    int Intelligence;
    int Vitality;
    public static CharacterStats operator +(CharacterStats a, CharacterStats b)
    {
        CharacterStats stats = new CharacterStats(a.Level + b.Level, a.Health + b.Health, a.Mana + b.Mana, a.Strength + b.Strength,
            a.Dexterity + b.Dexterity, a.Intelligence + b.Intelligence, a.Vitality + b.Vitality);
        return stats;
    }
    public static CharacterStats operator -(CharacterStats a, CharacterStats b)
    {
        CharacterStats stats = new CharacterStats(a.Level - b.Level, a.Health - b.Health, a.Mana - b.Mana, a.Strength - b.Strength,
            a.Dexterity - b.Dexterity, a.Intelligence - b.Intelligence, a.Vitality - b.Vitality);
        return stats;
    }
    public static CharacterStats operator *(CharacterStats a, CharacterStats b)
    {
        CharacterStats stats = new CharacterStats(a.Level * b.Level, a.Health * b.Health, a.Mana * b.Mana, a.Strength * b.Strength,
            a.Dexterity * b.Dexterity, a.Intelligence * b.Intelligence, a.Vitality * b.Vitality);
        return stats;
    }
}


