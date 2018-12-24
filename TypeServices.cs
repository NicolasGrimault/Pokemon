using System.Linq;
using System.Collections;
using E = Pokemon.Efficience;

namespace Pokemon
{
    public class TypeServices
    {
        // Defense : Normal,Fighting,Flying,Poison,Ground,Rock,Bug,Ghost,Steel,Fire,Water,Grass,Electric,Psychic,Ice,Dragon,Dark,Fairy
        private static Efficience[,] table = new Efficience[18, 18]
        {{E.Effective,E.SuperEffective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective},
        {E.Effective,E.Effective,E.SuperEffective,E.Effective,E.Effective,E.NotVeryEffective ,E.NotVeryEffective ,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.SuperEffective,E.Effective,E.Effective,E.NotVeryEffective ,E.SuperEffective},
        {E.Effective,E.NotVeryEffective ,E.Effective,E.Effective,E.NoEffect  ,E.SuperEffective,E.NotVeryEffective ,E.Effective,E.Effective,E.Effective,E.Effective,E.NotVeryEffective ,E.SuperEffective,E.Effective,E.SuperEffective,E.Effective,E.Effective,E.Effective},
        {E.Effective,E.NotVeryEffective ,E.Effective,E.NotVeryEffective ,E.SuperEffective,E.Effective,E.NotVeryEffective ,E.Effective,E.Effective,E.Effective,E.Effective,E.NotVeryEffective ,E.Effective,E.SuperEffective,E.Effective,E.Effective,E.Effective,E.NotVeryEffective },
        {E.Effective,E.Effective,E.Effective,E.NotVeryEffective ,E.Effective,E.NotVeryEffective ,E.Effective,E.Effective,E.Effective,E.Effective,E.SuperEffective,E.SuperEffective,E.NoEffect  ,E.Effective,E.SuperEffective,E.Effective,E.Effective,E.Effective},
        {E.NotVeryEffective ,E.SuperEffective,E.NotVeryEffective ,E.NotVeryEffective ,E.SuperEffective,E.Effective,E.Effective,E.Effective,E.SuperEffective,E.NotVeryEffective ,E.SuperEffective,E.SuperEffective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective},
        {E.Effective,E.NotVeryEffective ,E.SuperEffective,E.Effective,E.NotVeryEffective ,E.SuperEffective,E.Effective,E.Effective,E.Effective,E.SuperEffective,E.Effective,E.NotVeryEffective ,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective},
        {E.NoEffect  ,E.NoEffect  ,E.Effective,E.NotVeryEffective ,E.Effective,E.Effective,E.NotVeryEffective ,E.SuperEffective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.SuperEffective,E.Effective},
        {E.NotVeryEffective ,E.SuperEffective,E.NotVeryEffective ,E.NoEffect  ,E.SuperEffective,E.NotVeryEffective ,E.NotVeryEffective ,E.Effective,E.NotVeryEffective ,E.SuperEffective,E.Effective,E.NotVeryEffective ,E.Effective,E.NotVeryEffective ,E.NotVeryEffective ,E.NotVeryEffective ,E.Effective,E.NotVeryEffective },
        {E.Effective,E.Effective,E.Effective,E.Effective,E.SuperEffective,E.SuperEffective,E.NotVeryEffective ,E.Effective,E.NotVeryEffective ,E.NotVeryEffective ,E.SuperEffective,E.NotVeryEffective ,E.Effective,E.Effective,E.NotVeryEffective ,E.Effective,E.Effective,E.NotVeryEffective },
        {E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.NotVeryEffective ,E.NotVeryEffective ,E.NotVeryEffective ,E.SuperEffective,E.SuperEffective,E.Effective,E.NotVeryEffective ,E.Effective,E.Effective,E.Effective},
        {E.Effective,E.Effective,E.SuperEffective,E.SuperEffective,E.NotVeryEffective ,E.Effective,E.SuperEffective,E.Effective,E.Effective,E.SuperEffective,E.NotVeryEffective ,E.NotVeryEffective ,E.NotVeryEffective ,E.Effective,E.SuperEffective,E.Effective,E.Effective,E.Effective},
        {E.Effective,E.Effective,E.NotVeryEffective ,E.Effective,E.SuperEffective,E.Effective,E.Effective,E.Effective,E.NotVeryEffective ,E.Effective,E.Effective,E.Effective,E.NotVeryEffective ,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective},
        {E.Effective,E.NotVeryEffective ,E.Effective,E.Effective,E.Effective,E.Effective,E.SuperEffective,E.SuperEffective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.NotVeryEffective ,E.Effective,E.Effective,E.SuperEffective,E.Effective},
        {E.Effective,E.SuperEffective,E.Effective,E.Effective,E.Effective,E.SuperEffective,E.Effective,E.Effective,E.SuperEffective,E.SuperEffective,E.Effective,E.Effective,E.Effective,E.Effective,E.NotVeryEffective ,E.Effective,E.Effective,E.Effective},
        {E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.NotVeryEffective ,E.NotVeryEffective ,E.NotVeryEffective ,E.NotVeryEffective ,E.Effective,E.SuperEffective,E.SuperEffective,E.Effective,E.SuperEffective},
        {E.Effective,E.SuperEffective,E.Effective,E.Effective,E.Effective,E.Effective,E.SuperEffective,E.NotVeryEffective ,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.NoEffect  ,E.Effective,E.Effective,E.NotVeryEffective ,E.SuperEffective},
        {E.Effective,E.NotVeryEffective ,E.Effective,E.SuperEffective,E.Effective,E.Effective,E.NotVeryEffective ,E.Effective,E.SuperEffective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.Effective,E.NoEffect  ,E.NotVeryEffective ,E.Effective}};


        public static int GetTypeEfficience(@Type attackType, @Type defenseType)
        {
            return (int)table[(int)attackType, (int)defenseType];
        }

    }
}