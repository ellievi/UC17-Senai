using Microsoft.AspNetCore.Mvc;
using Moq;
using SenaiUC17.Controllers;
using SenaiUC17.Interface_s;
using SenaiUC17.Models;
using SenaiUC17.ViewModels;
using System.IdentityModel.Tokens.Jwt;

namespace TesteIntegracao
{
    public class LoginControllerTeste
    {
        [Fact]
        public void LoginController_Retornar_Usuario_Invalido()
        {
            var repositoryEspelhado = new Mock<IUsuarioRepository>();
            repositoryEspelhado.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);
            
            var controller = new LoginController(repositoryEspelhado.Object);
            
            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "email@email.com";
            dadosUsuario.senha = "senha1234";

            var resultado = controller.Login(dadosUsuario);

            Assert.IsType<UnauthorizedObjectResult>(resultado);
  
        }

        [Fact]
        public void LoginController_Retornar_Token()
        {                        
            Usuario usuarioRetornado = new Usuario();
            usuarioRetornado.Email = "emailteste@email.com";
            usuarioRetornado.Senha = "1234";
            usuarioRetornado.Tipo = "0";
            usuarioRetornado.id = 1;

            var repositoryEspelhado = new Mock<IUsuarioRepository>();
            repositoryEspelhado.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()));

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "emaaail@email.com";
            dadosUsuario.senha = "senha123";

            var controller = new LoginController(repositoryEspelhado.Object);
            string issuerValido = "chapter.webapi";


            OkObjectResult resultado = (OkObjectResult)controller.Login(dadosUsuario);
            string tokenString = resultado.Value.ToString().Split(' ')[3];

            var jwtHandler = new JwtSecurityTokenHandler();
            var tokenJet = jwtHandler.ReadJwtToken(tokenString);


            Assert.Equal(issuerValido, tokenJet.Issuer);
        }
    }
}