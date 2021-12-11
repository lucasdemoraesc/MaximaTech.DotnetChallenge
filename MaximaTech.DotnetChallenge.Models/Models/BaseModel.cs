using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MaximaTech.DotnetChallenge.Domain.Models
{
    /// <summary>
    /// Classe abstrata base para objetos do domínio.
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Representa o identificador da entidade utilizado internamente.
        /// </summary>
        [JsonIgnore]
        public Guid Id { get; set; }

        /// <summary>
        /// Representa o código da entidade visível ao usuário.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "O campo Código deve ser informado.")]
        public int Codigo { get; set; }

        /// <summary>
        /// Informa se a entidade está ativa ou não no sistema.
        /// </summary>
        public bool Status { get; set; } = false;
    }
}
