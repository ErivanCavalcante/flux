export class MovimentacaoCreateDto {
    public tipo: string = '';
    public valor: number = 0;
    public descricao: string = '';

    constructor(parameters?: any) {
        if (parameters) {
            this.tipo = parameters.tipo;
            this.valor = parameters.valor;
            this.descricao = parameters.descricao;
        }
    }
}