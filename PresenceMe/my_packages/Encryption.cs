using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Encryption
{
    public static byte[] ComputeSha256Hash(object obj)
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            bf.Serialize(ms, obj);
            byte[] data = ms.ToArray();

            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(data);
            }
        }
    }
}
