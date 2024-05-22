namespace KMZI_Lab15
{
    public class Lab15Main
    {
        public static void Main()
        {
            var openText = "artsy";
            Steganography.HideMessage(openText);
            Steganography.ShowMessage();
        }
    }
}