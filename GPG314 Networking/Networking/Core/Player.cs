namespace Core
{
    public class Player
    {
        public string Name { get; private set; }
        public string ID { get; private set; }

        public Player(string id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
