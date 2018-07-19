namespace Pokemon
{
    public class Move
    {
        public string Name { get; set; }
        public int Accuracy { get; set; }
        public MoveType MoveType { get; set; }
        public @Type type { get; set; }
        public string Description { get; set; }
        public int Power { get; set; }
    }
}