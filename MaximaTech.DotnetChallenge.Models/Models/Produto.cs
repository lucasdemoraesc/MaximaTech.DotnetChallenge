using System.ComponentModel.DataAnnotations;

namespace MaximaTech.DotnetChallenge.Domain.Models
{
    /// <summary>
    /// Classe que representa o recurso Produto no sistema.
    /// </summary>
    public class Produto : BaseModel
    {
        #region CONSTANTES DE VALIDACAO

        public const int TAMANHO_MAXIMO_DESCRICAO = 60;

        #endregion

        /// <summary>
        /// Obtém ou define a descrição de um produto.
        /// </summary>
        [Required(ErrorMessage = "O campo Descrição deve ser informado")]
        [MaxLength(TAMANHO_MAXIMO_DESCRICAO, ErrorMessage = "A Descrição deve conter no máximo 60 caracteres")]
        public string Descricao { get; set; }

        /// <summary>
        /// Obtém ou define o <see cref="Produto"/> de um produto.
        /// </summary>
        [Required(ErrorMessage = "Um Departamento deve ser selecionado")]
        public Departamento Departamento { get; set; }

        /// <summary>
        /// Obtém ou define o preço de um produto.
        /// </summary>
        [Required(ErrorMessage = "O campo Preço deve ser informado")]
        public decimal Preco { get; set; }
    }
}
