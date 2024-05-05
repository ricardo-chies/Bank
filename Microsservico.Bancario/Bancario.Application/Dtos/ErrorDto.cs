namespace Bancario.Application.Dtos
{
    public class ErrorDto
    {
        public string Erro { get; set; }
        public string Message { get; set; }
        public string Stack { get; set; }

        public ErrorDto(string erro, string message, string stack)
        {
            this.Erro = erro;
            this.Message = message;
            this.Stack = stack;
        }
    }
}