using Konscious.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace testcore13092022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private readonly ILogger<testController> logger;

        public testController(ILogger<testController> logger)
        {
            this.logger = logger;
        }


        #region GetCustomer

        [HttpGet]
        [Route("GetCustomer")]
        public string Get()
        {
            logger.LogInformation("this is the first log msg");
            logger.LogWarning("this is warning");

            Console.WriteLine("hello");


            return "Hello world!!!!!!";
        }
        #endregion


        //[HttpGet]
        //[Route("hashi")]
        //public string Gett()
        //{

        //    var buffer = new byte[16];
        //    var rng = new RNGCryptoServiceProvider();

        //    rng.GetBytes(buffer);
        //    var salt = buffer;
        //    Console.WriteLine("salt is", Convert.ToBase64String(salt));


        //    var password = "hiii";
        //    var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

        //    argon2.Salt = salt;
        //    argon2.DegreeOfParallelism = 8; // four cores
        //    argon2.Iterations = 4;
        //    argon2.MemorySize = 1024 * 1024; // 1 GB
        //    var hash = argon2.GetBytes(16);
        //    Console.WriteLine($"Hash is '{ Convert.ToBase64String(hash) }'.");

        //    var h = argon2.GetBytes(16);
        //    return "success";

        //}

        //[HttpGet]
        //[Route("verifyy")]
        //public string Gett()
        //{

        //}


        //private string test()
        //{
        //    var buffer = new byte[16];
        //    var rng = new RNGCryptoServiceProvider();
        //    Console.WriteLine("salt is", rng);
        //    rng.GetBytes(buffer);
        //    var salt = buffer;


        //    var password = "hiii";
        //    var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

        //    argon2.Salt = salt;
        //    argon2.DegreeOfParallelism = 8; // four cores
        //    argon2.Iterations = 4;
        //    argon2.MemorySize = 1024 * 1024; // 1 GB
        //    var hash = argon2.GetBytes(16);
        //    Console.WriteLine($"Hash is '{ Convert.ToBase64String(hash) }'.");

        //    var h = argon2.GetBytes(16);
        //    return "success";

        //}

        public string salt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            Console.WriteLine("salt is", rng);
            rng.GetBytes(buffer);
            var saltt = Convert.ToBase64String(buffer);
            Console.WriteLine($"var saltt is '{ Convert.ToBase64String(buffer) }'.");

            Console.WriteLine($"Using salt in createsalt '{ Convert.ToBase64String(buffer) }'.");

            return saltt;
        }
        public string passwordd()
        {
            var pass = "hello";
            return pass;
        }
        [HttpGet]
        [Route("hashing")]
        public string HashPassword()
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(passwordd()));
            var salttt = Encoding.UTF8.GetBytes("tyoWpm8iM5hpMLFn/Vh+wQ==");
            argon2.Salt = salttt;
            
            Console.WriteLine($"Using  argon salt  '{ Convert.ToBase64String(argon2.Salt) }'.");

            argon2.DegreeOfParallelism = 8; // four cores
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 1024; // 1 GB
            var hashh = Convert.ToBase64String(argon2.GetBytes(16));
           
            Console.WriteLine($"Hash is '{ Convert.ToBase64String(argon2.GetBytes(16)) }'.");
            return hashh;
        }

        

        [HttpGet]
        [Route("verifyhashh")]

        public bool VerifyHash()
        
        {
            
           
            string pwd = passwordd();
            var newHash =HashPassword();
            var hash = "y4WOQlv6PdDytLdEx4fXqw==";
            var result= hash.SequenceEqual(newHash);

            return result;
        }
        //[HttpGet]
        //[Route("Get")]
        //public void Run()
        //{
           
        //    var stopwatch = Stopwatch.StartNew();

        //    Console.WriteLine($"Creating hash for password '{ password }'.");

        //    var salt = CreateSalt();
        //    Console.WriteLine($"Using salt '{ Convert.ToBase64String(salt) }'.");

        //    var hash = HashPassword(password, salt);
        //    Console.WriteLine($"Hash is '{ Convert.ToBase64String(hash) }'.");

        //    stopwatch.Stop();
        //    Console.WriteLine($"Process took { stopwatch.ElapsedMilliseconds / 1024.0 } s");

        //    stopwatch = Stopwatch.StartNew();
        //    Console.WriteLine($"Verifying hash...");

        //    var success = VerifyHash(password, salt, hash);
        //    Console.WriteLine(success ? "Success!" : "Failure!");

        //    stopwatch.Stop();
        //    Console.WriteLine($"Process took { stopwatch.ElapsedMilliseconds / 1024.0 } s");
        //}
        //[HttpGet]
        //[Route("verifyy")]
        //private bool VerifyHash(string password, byte[] salt, byte[] hash)
        //{
        //    var newHash = HashPassword(password, salt);
        //    return hash.SequenceEqual(newHash);
        //}
        //[HttpGet]
        //[Route("Geting")]
        //public string verify()
        //{
        //    var password = "Hello World!";
        //    var stopwatch = Stopwatch.StartNew();

        //    Console.WriteLine($"Creating hash for password '{ password }'.");

        //    var salt = CreateSalt();
        //    Console.WriteLine($"Using salt '{ Convert.ToBase64String(salt) }'.");

        //    var hash = HashPassword(password, salt);
        //    Console.WriteLine($"Hash is '{ Convert.ToBase64String(hash) }'.");

        //    stopwatch.Stop();
        //    Console.WriteLine($"Process took { stopwatch.ElapsedMilliseconds / 1024.0 } s");

        //    stopwatch = Stopwatch.StartNew();
        //    Console.WriteLine($"Verifying hash...");

        //    var success = VerifyHash(password, salt, hash);
        //    Console.WriteLine(success ? "Success!" : "Failure!");

        //    stopwatch.Stop();
        //    Console.WriteLine($"Process took { stopwatch.ElapsedMilliseconds / 1024.0 } s");
        //}



        //[HttpGet]
        //[Route("verifyy")]
        //public bool VerifyHash(string password, byte[] salt, byte[] hash)
        //{
        //    var success = VerifyHash(password, salt, hash);
        //    Console.WriteLine(success ? "Success!" : "Failure!");

        //    stopwatch.Stop();
        //    Console.WriteLine($"Process took { stopwatch.ElapsedMilliseconds / 1024.0 } s");


        //}



    }
}
