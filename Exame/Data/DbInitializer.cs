using Exame.Models;
using Microsoft.AspNetCore.Identity;

namespace Exame.Data
{
    public class DbInitializer
    {
        private ApplicationDbContext _context;     
        private readonly UserManager<IdentityUser> _userManager;
            
        public DbInitializer(ApplicationDbContext context,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public void Run()
        {
            _context.Database.EnsureCreated();

            if (_context.Clubes.Any())
            {
                return;
            }
            var user = new IdentityUser
            {
                UserName = "Manel@xpto.com",
                Email = "Manel@xpto.com",
                EmailConfirmed = true
            };

            var password = "Password@123"; 

            var result = _userManager.CreateAsync(user, password).Result;

             user = new IdentityUser
            {
                UserName = "Ana@xpto.com",
                Email = "Ana@xpto.com",
                EmailConfirmed = true
            };

            

             result = _userManager.CreateAsync(user, password).Result;

            var _Clubes = new Clube[]
            {
                new Clube { Nome = "Sporting CP",Sigla="SCP",Foto="SCP.png" },
                new Clube { Nome = "SL Benfica",Sigla="SLB",Foto="SLB.png" },
                new Clube { Nome = "FC Porto",Sigla="FCP",Foto="FCP.png" }
                
            };

            _context.Clubes.AddRange(_Clubes);

            var _coments = new Comentario[]
            {
                new Comentario { User = "Ana@xpto.com",Data=DateTime.Now , Clube =  _Clubes.Single(c => c.Sigla == "SCP"),Texto="Este clube é o maior!!"},
                new Comentario { User = "Manel@xpto.com",Data=DateTime.Now.AddDays(-1) , Clube =  _Clubes.Single(c => c.Sigla == "SLB"),Texto="O Benfica tem mais campeonatos"},
           };

           _context.Comentarios.AddRange(_coments);

            _context.SaveChanges();
        }
    }
}
