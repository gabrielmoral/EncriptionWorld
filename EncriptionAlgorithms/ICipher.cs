namespace EncriptionAlgorithms
{
    public interface ICipher
    {
        string Decript(string text);

        string Encript(string text);
    }
}