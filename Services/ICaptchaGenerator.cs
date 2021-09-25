using Captcha.Models;

namespace Captcha.Services
{
    public interface ICaptchaGenerator
    {
        CaptchaDto Generate();
    }
}