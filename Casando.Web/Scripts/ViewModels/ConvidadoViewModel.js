(function () {

    $(function () {
        //debugger;
        ko.applyBindings(ConvidadosListVM);
        ConvidadosListVM.getConvidados();
    });

    var ConvidadoVM = {
        Nome: ko.observable(),
        Sobrenome: ko.observable(),
        Endereco: ko.observable(),
        Exibiveis: ko.observable()
    };

    var ConvidadosListVM = {
        Convidados: ko.observableArray([]),
        getConvidados: function () {
            
            $.ajax({
                url: '/Convidados/Teste',
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json',
                success: function (data) {
                    debugger;
                    Convidados(data);
                },
                error: function(err) {

                }
            });
        }
    };

    function Convidados(data) {
        this.Nome = ko.observable(data.Nome);
        this.Sobrenome = ko.observable(data.Sobrenome);
        this.Endereco = ko.observable(data.Endereco);
        this.Exibiveis = ko.observable(data.Exibiveis);
    };

})();
