$(document).ready(function () {
    $("#btnSave").on("click", function () {
        let useCode = useCodeGenerate();
        $("#UseCode").val(useCode);
        $("#formEdit").trigger("submit");
    });
    $('#Photo').on('change', function () {
        $("#btn-open-modal").click();
        readFile(this);
    });
});

function useCodeGenerate() {
    const chars = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    let sequence = '';

    // Gera os primeiros 3 caracteres numéricos
    for (let i = 0; i < 3; i++) {
        const randomIndex = Math.floor(Math.random() * 10); // Apenas números
        sequence += randomIndex;
    }

    // Adiciona o hífen
    sequence += '-';

    // Gera os próximos 4 caracteres alfanuméricos
    for (let i = 0; i < 4; i++) {
        const randomIndex = Math.floor(Math.random() * chars.length);
        sequence += chars.charAt(randomIndex);
    }

    return sequence;
}

function setProfilePhotoOnCard() {
    const file = event.target.files[0];
    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            const img = $(".img-card-photo")[0];
            img.src = e.target.result;
            img.style.display = 'block';
        }
        reader.readAsDataURL(file);
    }
} 

function readFile(input) {
    if (input.files && input.files[0]) {
        let reader = new FileReader();

        reader.onload = function (e) {
            $('.div-card-photo').croppie('bind', {
                url: e.target.result
            });
        }
        reader.readAsDataURL(input.files[0]);
    }
}