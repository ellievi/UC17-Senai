﻿using System.ComponentModel.DataAnnotations;

namespace SenaiUC17.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o email do usuário")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string senha { get; set; }
    }
}
