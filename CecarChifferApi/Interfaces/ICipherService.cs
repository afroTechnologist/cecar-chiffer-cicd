namespace CecarChifferApi.Interfaces
{
    public interface ICipherService
    {
        string Encrypt(string input, int shift);
        string Decrypt(string input, int shift);
    }
}
