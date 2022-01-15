namespace Domain.Entities
{
    public class UsuarioEntity : BaseEntity {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int Ativo { get; set; }
    }
}