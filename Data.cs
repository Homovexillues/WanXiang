namespace WanXiang
{
    public class Move
    {
        public int preMove { get; set; }
    }

    public class Test
    {
        public void test1()
        {
            Dictionary<Move, (int id, DateTime timestamp)> moveDict = new Dictionary<Move, (int, DateTime)>();
            Console.WriteLine(ActiveMoves[0].preMove);
        }

        internal static List<Move> ActiveMoves { get; } = [];
    }
}