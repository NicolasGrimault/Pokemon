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
        public @Type Type2 { get; set; }
    }
}