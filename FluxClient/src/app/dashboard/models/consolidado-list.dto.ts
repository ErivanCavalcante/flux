export class ConsolidadoListDto {
    public name: string = '';
    public value: string = '';

    constructor(parameters?: any) {
        if (parameters) {
            this.name = parameters.name;
            this.value = parameters.value;
        }
    }
}