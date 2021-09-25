using System.ComponentModel.DataAnnotations;

namespace Captcha.Models
{
    public class CaptchaModel
    {
        [Required]
        public string Key { get; set; }
        [Required]
        public string Text { get; set; }
    }
}