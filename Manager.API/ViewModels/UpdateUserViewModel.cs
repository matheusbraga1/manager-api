﻿using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class UpdateUserViewModel
    {
        [Required(ErrorMessage = "O ID não pode ser vazio.")]
        [Range(1, long.MaxValue, ErrorMessage = "O ID não pode ser menor que 1.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome não pode ser vazio.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email não pode ser vazio.")]
        [MinLength(10, ErrorMessage = "O e-mail deve ter no mínimo 10 caracteres.")]
        [MaxLength(180, ErrorMessage = "O e-mail deve ter no máximo 180 caracteres.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O nome não pode ser vazio.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        public string Password { get; set; }
    }
}
