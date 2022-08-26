namespace Core
{
    public class MessagePacket : BasePacket
    {
        public string Message { get; private set; }

        public MessagePacket()
        {
            Message = " ";
        }

        public MessagePacket(string message, Player player) : base(player, PacketType.Message)
        {
            Message = message;
        }
        public override byte[] Serialize()
        {
            base.Serialize();
            bw.Write(Message);
            return msWriter.ToArray();
        }

        public override BasePacket Deserialize(byte[] buffer)
        {
            base.Deserialize(buffer);
            Message = br.ReadString();
            return this;
        }
    }
}
