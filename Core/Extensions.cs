namespace Core
{
    public static class Extensions
    {
        public static void ReverseBuffer(this BinaryWriter writer, MemoryStream stream, byte[] buffer)
        {
            Array.Reverse(buffer);
            stream.Position -= buffer.Length;
            writer.Write(buffer);
        }

        public static string ConsoleName(this SaveType saveType) {
            if (saveType == SaveType.Switch || saveType == SaveType.Switch_B)
                return "Switch";
            else if (saveType == SaveType.WiiU || saveType == SaveType.WiiU_B)
                return "Wii U";
            else
                return "Unknown";
        }



        public static SaveType Reverse(this SaveType saveType)
        {
            uint value = (uint)saveType;
            return (SaveType)((value & 0x0000_00FFU) << 24 | (value & 0x0000_FF00U) << 8 |
                (value & 0x00FF_0000U) >> 8 | (value & 0xFF000_000U) >> 24);
        }
    }
}
