using System;
using System.Linq;
using Captcha.Configuration;
using Captcha.Models;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLaborsCaptcha;
using SixLaborsCaptcha.Core;

namespace Captcha.Services
{
    public class CaptchaGenerator : ICaptchaGenerator
    {
        private readonly CaptchaConfiguration _captchaConfiguration;

        public CaptchaGenerator(CaptchaConfiguration captchaConfiguration)
        {
            _captchaConfiguration = captchaConfiguration;
        }

        public CaptchaDto Generate()
        {
            var captcha = new SixLaborsCaptchaModule(new SixLaborsCaptchaOptions
            {
                DrawLines = _captchaConfiguration.DrawLines,
                MaxRotationDegrees = _captchaConfiguration.MaxRotationDegrees,
                Width = _captchaConfiguration.Width,
                Height = _captchaConfiguration.Height,
                FontSize = _captchaConfiguration.FontSize,
                FontStyle = Enum.Parse<FontStyle>(_captchaConfiguration.FontStyle),
                EncoderType = EncoderTypes.Png,
                FontFamilies = _captchaConfiguration.FontFamilies,
                TextColor = _captchaConfiguration.TextColor.Select(GetColorByName).ToArray(),
                DrawLinesColor = _captchaConfiguration.DrawLinesColor.Select(GetColorByName).ToArray()
            });

            var text = Extentions.GetUniqueKey(6);
            var image = captcha.Generate(text);
            return new CaptchaDto(text, image);
        }
        
        private static Color GetColorByName(string colorName)
        {
            var colorStruct = typeof(Color);
            var fValue = colorStruct.GetField(colorName);
            if (fValue is not null)
            {
                return (Color)fValue.GetValue(colorStruct);
            }
            return Color.Black;
        }
    }
}