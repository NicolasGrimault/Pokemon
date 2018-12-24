namespace Pokemon
{
    public class Pokemon
    {
        public string name { get; set; }
        public int HitPoint { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public @Type Type1 { get; set; }
        public @Type? Type2 { get; set; }
        public int Level { get; set; }


        public int GetAttaque(MoveType type)
        {
            if (type == MoveType.Physics)
                return this.Attack;
            else if (type == MoveType.Special)
                return this.SpecialAttack;
            else return 0;
        }

        public int GetDefense(MoveType type)
        {
            if (type == MoveType.Physics)
                return this.Defense;
            else if (type == MoveType.Special)
                return this.SpecialDefense;
            else return 0;
        }

        public bool IsType(@Type type)
        {
            return Type1 == type || Type2 == type;
        }

        public double GetTypeMultiplicator(@Type type)
        {
            int eff = TypeServices.GetTypeEfficience(this.Type1, type);

            if(Type2.HasValue){
                eff = eff * TypeServices.GetTypeEfficience(this.Type2.Value, type);
            }
            return eff / 10000;
        }
    }
}