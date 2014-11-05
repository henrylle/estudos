var convidadoViewModel = (function ConvidadoViewModel() {

    var self = this;
    var tiposConvidado = ko.observableArray(['Familiar do Noivo', 'Familiar da Noiva', 'Amigo do Noivo', 'Amigo da Noiva']);

    self.Convidados = ko.observableArray([]);
    self.novoConvidado = ko.observable();

    this.preencheTable = function () {
        self.Convidados([]);
        $.ajax({
            url: '/Convidados/Teste',
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                data.map(function (convidado) {
                    
                    self.Convidados.push(new Convidado(convidado));
                });
            },
            error: function (err) { }
        });
    }

    this.adicionar = function (dado) {
         
        $.ajax({
            url: '/Convidados/SalvaTeste',
            type: 'POST',
            dataType: 'json',
            data: ko.toJSON(dado),
            contentType: 'application/json',
            accept: 'application/json',
            statusCode: {
                200: function () {
                    self.preencheTable();
                }
            }
        });
    }

    this.preparaConvidado = function() {
        self.novoConvidado(new Convidado({}));
    }

    this.tiposDeConvidados = function() {
        return tiposConvidado;
    }

    /*Declaração do Objeto*/
    function Convidado(data) {
        this.Nome = ko.observable(data.Nome);
        this.Sobrenome = ko.observable(data.Sobrenome);
        this.Endereco = ko.observable(data.Endereco);
        this.NumeroConvites = ko.observable(data.NumeroConvites);
        this.TipoConvidado = ko.observable(data.TipoConvidado);
    };
});

$(function () {
    var viewModel = new convidadoViewModel();
    
    ko.applyBindings(viewModel, $(".convidados")[0]);
    viewModel.preencheTable();
    viewModel.preparaConvidado();
});
