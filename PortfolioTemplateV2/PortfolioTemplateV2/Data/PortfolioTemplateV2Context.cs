using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioTemplateV2.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace PortfolioTemplateV2.Data
{
    public class PortfolioTemplateV2Context : DbContext
    {
        public PortfolioTemplateV2Context (DbContextOptions<PortfolioTemplateV2Context> options)
            : base(options)
        {
        }

        public DbSet<PortfolioTemplateV2.Models.Project> Project { get; set; }

        public DbSet<PortfolioTemplateV2.Models.Credential> Credential { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            String Salt = generateSalt();

            modelBuilder.Entity<Credential>().HasData(
                    new Credential
                    {
                        Id = 1,
                        UserName = "admin",
                        Salt = Salt,
                        Password = hashThis("password", Salt)
                    }
                ); ; 

        }

        public string generateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public string hashThis(string inputPass, string inputSalt)
        {
            byte[] salt = Encoding.ASCII.GetBytes(inputSalt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: inputPass,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
