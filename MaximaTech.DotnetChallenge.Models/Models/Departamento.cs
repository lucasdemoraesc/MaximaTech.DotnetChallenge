using System.ComponentModel.DataAnnotations;

namespace MaximaTech.DotnetChallenge.Domain.Models
{
    /// <summary>
    /// Classe que representa o recurso Departamento no sistema.
    /// </summary>
    public class Departamento : BaseModel
    {
        #region CONSTANTES DE VALIDACAO

        public const int TAMANHO_MAXIMO_DESCRICAO = 60;

        #endregion

        /// <summary>
        /// Obtém ou define a descrição de um departamento.
        /// </summary>
        public string Descricao { get; set; }
    }
}