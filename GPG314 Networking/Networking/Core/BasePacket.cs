using System.IO;

namespace Core
{
    public class BasePacket
    {
        protected MemoryStream msWriter;
        protected BinaryWriter bw;
        protected MemoryStream msReader;
        protected BinaryReader br;
        public enum PacketType { Unknown = -1, None, Message, Prefab }
        public PacketType type { get; private set; }
        public Player player { get; private set; }

        public BasePacket(Player player, PacketType type)
        {
            this.player = player;
            this.type = type;
        }

        public BasePacket()
        {
            player = null;
            type = PacketType.None;
        }

        public virtual byte[] Serialize()
        {
            msWriter = new MemoryStream();
            bw = new BinaryWriter(msWriter);

            bw.Write((int)type);
            bw.Write(player.ID);
            bw.Write(player.Name);

            return null;
        }
        public virtual BasePacket Deserialize(byte[] buffer)
        {
            msReader = new MemoryStream(buffer);
            br = new BinaryReader(msReader);
            type = (PacketType)br.ReadInt32();
            player = new Player(br.ReadString(), br.ReadString());

            return this;
        }
    }
}
