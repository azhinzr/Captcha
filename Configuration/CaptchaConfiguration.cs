namespace Captcha.Configuration
{
    public class CaptchaConfiguration
    {
        public byte DrawLines { get; set; }
        public byte MaxRotationDegrees { get; set; }
        public byte Width { get; set; }
        public byte Height { get; set; }
        public byte FontSize { get; set; }
        public string FontStyle { get; set; }
        public string[] FontFamilies { get; set; }
        public string[] TextColor { get; set; }
        public string[] DrawLinesColor { get; set; }
    }
}