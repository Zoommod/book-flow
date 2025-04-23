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

    // Animação de fade para a mensagem de sucesso
    const mensagem = document.getElementById("mensagem-aviso");
    if (mensagem) {
        setTimeout(() => {
            mensagem.classList.add("fade-out");
            setTimeout(() => {
                mensagem.remove();
            }, 500); // Espera a transição terminar antes de remover do DOM
        }, 3000);
    }
});
