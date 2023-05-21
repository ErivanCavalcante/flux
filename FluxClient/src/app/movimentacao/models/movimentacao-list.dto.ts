export class MovimentacaoListDto {
    public id: string = '';
    public tipoMovimentacao: string = '';
    public valor: number = 0;
    public ultimoSaldo: number = 0;
    public descricao: string = '';
    public data: Date = new Date();

    constructor(parameters?: any) {
        if (parameters) {
            this.id = parameters.id;
            this.tipoMovimentacao = parameters.tipoMovimentacao;
            this.valor = parameters.valor;
            this.ultimoSaldo = parameters.ultimoSaldo;
            this.descricao = parameters.descricao;
            this.data = parameters.data;
        }
    }
}