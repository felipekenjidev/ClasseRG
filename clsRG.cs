using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Classe com Métodos de Validação de RG
/// </summary>
public class RG
{
    /// <summary>
    /// Construtor da Classe para formatação de Dígitos
    /// </summary>
    /// <param name="digitos">Dígitos do RG</param>
    /// <exception cref="ArgumentException">Erro adquirido ao inserir dígitos que não correspondam a um RG</exception>
    public RG(string digitos)
    {
        //Verificação do Formato do RG Inserido
        digitos = digitos.Replace(".", "").Replace("-", "").Trim();
        if (String.IsNullOrEmpty(digitos))
            throw new ArgumentException("O RG não pode ser vazio.");
        if (digitos.Length != 9)
            throw new ArgumentException("O RG deve possuir todos os 9 dígitos.");
        if (digitos.EndsWith("X"))
        {
            if (!long.TryParse(digitos.Substring(0, 8), out long digitosFormatadosSemVerificador))
                throw new ArgumentException("O RG deve ser composto somente por dígitos numéricos ou caractere X.");
        }
        else
        {
            if (!long.TryParse(digitos, out long digitosFormatados))
                throw new ArgumentException("O RG deve ser composto somente por dígitos numéricos ou caractere X.");
        }

        //Guardar os Dígitos do RG
        this.Digitos = digitos;
    }

    /// <summary>
    /// Propriedade que guarda todos os Dígitos do RG
    /// </summary>
    public string Digitos { get; set; }

    /// <summary>
    /// Método que retorna a validade do Documento RG
    /// </summary>
    /// <returns>Retorna a Validade do Documento</returns>
    public bool Validar()
    {
        //Caso haja somente números iguais, retornar que é Falso o Documento
        if (this.Digitos == new string(Convert.ToChar(this.Digitos.Substring(0, 1)), 8))
            return false;

        //Gerar o RG Válido e Padrão
        string digitoVerificador = GerarDigitoVerificador(this.Digitos.Substring(0, 8));
        string RGReal = Digitos.Substring(0, 8) + digitoVerificador;

        //Enviar resposta da Validação
        return this.Digitos == RGReal ? true : false;
    }

    //Método que realiza os cálculos para gerar o Dígito Verificador
    private string GerarDigitoVerificador(string digitos)
    {
        //Calcular as Multiplicações de cada Dígito do RG
        int soma = 0;
        int multiplicador = 2;
        for (int indice = 0; indice < digitos.Length; indice++)
        {
            soma += int.Parse(digitos.Substring(indice, 1)) * multiplicador;
            multiplicador++;
        }

        //Retornar o Dígito Validador
        int resto = soma % 11;
        if (resto > 1)
            return (11 - resto).ToString();
        else if (resto == 1)
            return "X";
        else
            return "0";
    }
}
