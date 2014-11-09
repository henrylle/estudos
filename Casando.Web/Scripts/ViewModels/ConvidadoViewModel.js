var convidadoViewModel = (function ConvidadoViewModel() {

    var self = this;
    self.tiposConvidado = ko.observableArray([{ Text: 'Familiar da Noiva', Value: 0 }, { Text: 'Familiar do Noivo', Value: 1 }, { Text: 'Amigo da Noiva', Value: 2 }, { Text: 'Amigo do Noivo', Value: 3 }, ]);
    self.Convidados = ko.observableArray([]);
    self.novoConvidado = ko.observable();

    this.preencheTable = function(categoria) {
        self.Convidados([]);
        $.ajax({
            url: '/Convidados/PorCategoria?obj=' + categoria,
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            accept: 'application/json',
            statusCode: {
                200: function (data) {
                    data.map(function (convidado) {
                        self.Convidados.push(new Convidado(convidado));
                    });
                }
            }
        });
    };

    this.adicionar = function(dado) {
        
        $.ajax({
            url: '/Convidados/Salvar',
            type: 'POST',
            dataType: 'json',
            data: ko.toJSON(dado),
            contentType: 'application/json',
            accept: 'application/json',
            statusCode: {
                200: function() {
                    self.preencheTable(dado.TipoConvidado());
                }
            }
        });
    };

    this.editar = function(id) {
        $.ajax({
            url: '/Convidados/Editar/' + id,
            type: 'GET',
            statusCode: {
                200: function (data) {
                    self.novoConvidado(data);
                }
            }
        });
    };

    this.editarSalvar = function (dado) {

        $.ajax({
            url: '/Convidados/Editar',
            type: 'POST',
            dataType: 'json',
            data: ko.toJSON(dado),
            contentType: 'application/json',
            accept: 'application/json',
            statusCode: {
                200: function () {
                    self.preencheTable(dado.TipoConvidado);
                }
            }
        });
    };

    this.preparaConvidado = function() {
        self.novoConvidado(new Convidado({}));
    };

    this.tiposDeConvidados = function() {
        return tiposConvidado;
    };

    /*Declaração do Objeto*/
    function Convidado(data) {
        this.Id = ko.observable(data.Id);
        this.Nome = ko.observable(data.Nome);
        this.Sobrenome = ko.observable(data.Sobrenome);
        this.Endereco = ko.observable(data.Endereco);
        this.NumeroDeExibiveis = ko.observable(data.NumeroDeExibiveis);
        this.TipoConvidado = ko.observable(data.TipoConvidado);
        this.ComConvite = ko.observable(data.ComConvite);
    };
});

$(function () {
    var viewModel = new convidadoViewModel();
    
    ko.applyBindings(viewModel, $(".convidados")[0]);
    viewModel.preencheTable('1');
    viewModel.preparaConvidado();
    
});
