$(document).ready(function () {
    // Inicializa o DataTables
    $('#loanTable').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.4/i18n/pt-BR.json'
        }
    });

    // Verifica se há erros de validação no ModelState
    var hasValidationErrors = $('span.field-validation-error').length > 0;
    if (hasValidationErrors) {
        var modal = new bootstrap.Modal(document.getElementById('addLoanModal'));
        modal.show();
    }
});
