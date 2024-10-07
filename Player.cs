namespace Connect4ConsoleGame
{
    class Player
    {
        public int Number { get; private set; }

        public Player(int number)
        {
            Number = number;
        }

        public void Switch()
        {
            Number = Number == 1 ? 2 : 1;
        }
    }
}
