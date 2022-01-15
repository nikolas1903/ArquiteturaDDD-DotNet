namespace Domain.Utils
{
    public class RespostaPadrao
    {
        public string message { get; set; }
        public bool success { get; set; }

        public object data { get; set; }

        public RespostaPadrao Sucesso(string mensagem, object objeto)
        {
            return new RespostaPadrao()
            {
                success = true,
                message = mensagem,
                data = objeto
            };
        }
        
        public RespostaPadrao Falha(string mensagem, object objeto)
        {
            return new RespostaPadrao()
            {
                success = false,
                message = mensagem,
                data = objeto
            };
        }
    }
}