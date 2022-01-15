using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key] 
        public int Id { get; set; }
        
        private DateTime? _dataCriacao;
        public DateTime? DataCriacao
        {
            get => _dataCriacao;
            set => _dataCriacao = value ?? DateTime.UtcNow;
        }
    }
}