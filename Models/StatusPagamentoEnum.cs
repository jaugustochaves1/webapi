namespace webapi.Models
{
    public enum StatusPagamentoEnum
    {
        //"Aguardando pagamento", “Pagamento aprovado” | “Enviado para transportadora” | “Entregue” | “Cancelada”
        AGUARDANDO_PAGAMENTO = 1,
        PAGAMENTO_APROVADO = 2,
        ENVIADO_PARA_TRANSPORTADORA = 3,
        ENTREGUE = 4,
        CANCELADA = 5
    }
}
