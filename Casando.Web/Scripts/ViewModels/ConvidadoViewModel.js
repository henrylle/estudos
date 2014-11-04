var convidadoViewModel = (function ConvidadoViewModel() {

    var self = this;

    self.Convidados = ko.observableArray([]);

    this.preencheTable = function () {
        $.ajax({
            url: '/Convidados/Teste',
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                data.map(function (convidado) {
                    //debugger;
                    self.Convidados.push(new Convidado(convidado));
                });
            },
            error: function (err) { }
        });
    }

    /*Declaração do Objeto*/
    function Convidado(data) {
        this.Nome = ko.observable(data.Nome);
        this.Sobrenome = ko.observable(data.Sobrenome);
        this.Endereco = ko.observable(data.Endereco);
        this.Exibiveis = ko.observable(data.NumeroConvites);
    };
});

$(function () {
    var viewModel = new convidadoViewModel();
    ko.applyBindings(viewModel, $(".table")[0]);
    viewModel.preencheTable();
});
