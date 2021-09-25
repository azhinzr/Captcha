namespace Captcha.Models
{
    public class CaptchaDto
    {
        public string Text { get; }
        public byte[] Image { get; }

        public CaptchaDto(string text, byte[] image)
        {
            Text = text;
            Image = image;
        }
    }
}