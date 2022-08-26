namespace Core
{
    public class InstantiatePacket : BasePacket
    {
        public string PrefabName;

        public InstantiatePacket()
        {
            PrefabName = "";
        }

        public InstantiatePacket(string prefabName, Player player) : base(player, PacketType.Prefab)
        {
            PrefabName= prefabName;
        }

        public override byte[] Serialize()
        {
            base.Serialize();
            bw.Write(PrefabName);
            return msWriter.ToArray();
        }

        public override BasePacket Deserialize(byte[] buffer)
        {
            base.Deserialize(buffer);
            PrefabName = br.ReadString();
            return this;
        }
    }
}
