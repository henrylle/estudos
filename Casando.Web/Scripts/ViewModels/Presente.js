var presenteViewModel = (function PresenteViewModel() {
    var self = this;
    self.Presentes = ko.observableArray([]);
    self.novoPresente = ko.observable();

    self.Presente = function Presente(data) {
        data = data || {};

        this.Id = ko.observable(data.Id);
        this.Nome = ko.observable(data.Nome);
        this.Cotacoes = ko.observableArray(data.Cotacoes ? $.map(data.Cotacoes, function (cotacao) {
            return new self.Cotacao(cotacao);
        }) : []);
    };

    self.Cotacao = function Cotacao(data) {
        data = data || {};

        this.Id = ko.observable(data.Id);
        this.SiteNome = ko.observable(data.SiteNome);
        this.Url = ko.observable(data.Url);
        this.Valor = ko.observable(data.Valor);
    };

    this.preencheTable = function() {
        self.Presentes([]);
        $.ajax({
            url: '/Presentes/Todos',
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            accept: 'application/json',
            statusCode: {
                200: function (data) {
                    data.map(function (p) {
                        self.Presentes.push(new Presente(p));
                    });
                }
            }
        });
    };

    this.adicionar = function (data) {
        
        $.ajax({
            url: 'Presentes/Novo',
            type: 'POST',
            dataType: 'json',
            data: ko.toJSON(data),
            contentType: 'application/json',
            statusCode: {
                200: function() {
                    location.reload();//Gambs!
                }
            }
        });
    };

    this.preparaPresente = function() {
        self.novoPresente({
            Nome: ko.observable(),
            SiteNome: ko.observable(),
            Url: ko.observable(),
            Valor: ko.observable()
        });
    };
});

$(function() {
    var viewModel = new presenteViewModel();
    ko.applyBindings(viewModel, $(".presentes")[0]);
    //viewModel.preencheTable();
    viewModel.preparaPresente();
});