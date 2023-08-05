using System;
using System.Collections.Generic;
using System.Linq;

public class PasswordValidator
{
    public bool IsValid(string password)
    {
        // Verifica se a senha possui nove ou mais caracteres
        if (password.Length < 9)
        {
            return false;
        }

        // Verifica se a senha possui ao menos 1 número
        if (!password.Any(char.IsDigit))
        {
            return false;
        }

        // Verifica se a senha possui ao menos 1 letra minúscula
        if (!password.Any(char.IsLower))
        {
            return false;
        }

        // Verifica se a senha possui ao menos 1 letra maiúscula
        if (!password.Any(char.IsUpper))
        {
            return false;
        }

        // Verifica se a senha possui ao menos 1 caractere especial
        var specialChars = new HashSet<char> { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+' };
        if (!password.Any(c => specialChars.Contains(c)))
        {
            return false;
        }

        // Verifica se a senha não possui caracteres repetidos
        if (password.Distinct().Count() != password.Length)
        {
            return false;
        }

        // Se todas as verificações passarem, a senha é válida
        return true;
    }
}
