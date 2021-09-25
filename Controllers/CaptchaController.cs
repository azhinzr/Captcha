using System;
using System.IO;
using Captcha.Models;
using Captcha.Configuration;
 using Captcha.Services;
using LazyCache;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Captcha.Controllers
{
    [ApiController]
    [Route("captcha")]
    public class CaptchaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly CacheConfiguration _cacheConfiguration;
        private readonly ICaptchaGenerator _captchaGenerator;
        private readonly IAppCache _cache;

        public CaptchaController(IConfiguration configuration, CacheConfiguration cacheConfiguration, ICaptchaGenerator captchaGenerator, IAppCache cache)
        {
            _configuration = configuration;
            _cacheConfiguration = cacheConfiguration;
            _captchaGenerator = captchaGenerator;
            _cache = cache;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var captcha = _captchaGenerator.Generate();
            var stream = new MemoryStream(captcha.Image);
            var key = Guid.NewGuid().ToString();
            var fileName = $"{key}.png";
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_cacheConfiguration.ExpirationInMinutes),
            };

            _cache.Add(key, captcha.Text.ToLower(), cacheOptions);

            return new FileStreamResult(stream, "image/png")
            {
                FileDownloadName = fileName
            };
        }

        [HttpPost]
        public ApiResult<bool> Post([FromBody] CaptchaModel model)
        {
            var text = _cache.Get<string>(model.Key);
            return ApiResult<bool>.StandardOk(text == model.Text.ToLower());
        }
    }
}