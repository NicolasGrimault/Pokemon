using System;

namespace Pokemon
{
    public class BattleServices
    {
        public int ComputeDamage(Pokemon attacker, Pokemon defender, Move move)
        {
            int Lvl = attacker.Level;
            int Att = attacker.GetAttaque(move.MoveType);
            int Pow = move.Power;
            int Def = defender.GetDefense(move.MoveType);
            double Ce = ComputeCe(attacker, defender, move);
            int damage = (int)Math.Ceiling((Lvl * 0.4 + 2) * Att * Pow * Ce / (Def * 50 + 2));
            return damage;
        }

        public double ComputeCe(Pokemon attacker, Pokemon defender, Move move)
        {
            double Ce = 1;
            if (attacker.IsType(move.type))
                Ce = Ce * 1.5;
            //TODO crits

            Ce = Ce * defender.GetTypeMultiplicator(move.type);
            return Ce;
        }
    }
}