export class MovimentacaoUpdateDto {
    public id: string = '';
    public descricao: string = '';

    constructor(parameters?: any) {
        if (parameters) {
            this.id = parameters.id;
            this.descricao = parameters.descricao;
        }
    }
}