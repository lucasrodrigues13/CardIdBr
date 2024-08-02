$(document).ready(function () {
    $("form input").on('change', function () {
        $(".text-name").html($("#FullName").val().toUpperCase());
        $(".text-instituition").html($("#InstituitionName").val().toUpperCase());
        $(".text-course").html($("#Course").val().toUpperCase());
        $(".text-cpf").html("<b>CPF:</b> " + $("#Cpf").val().toUpperCase());
        $(".text-rg").html("<b>RG:</b> " + $("#Rg").val().toUpperCase());
        $(".text-birthdate").html("<b>DATA DE NASC.:</b> " + $("#BirthDate").val().toUpperCase());
    });

    $("#btnSave").on("click", function () {
        let useCode = useCodeGenerate();
        $("#UseCode").val(useCode);
        $("#formEdit").trigger("submit");
    });

    let croppieInstance;
    $('#Photo').on('change', function () {
        const file = event.target.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = function (e) {
                $('#resizeModal').modal('show');

                if (croppieInstance) {
                    croppieInstance.destroy();
                }
                const image = document.getElementById('modal-img-card-photo');
                image.src = e.target.result;

                croppieInstance = new Cropper(image, {
                    aspectRatio: 113 / 144,
                    autoCropArea: 1,
                    movable: true,
                    zoomable: true,
                    rotatable: false,
                    scalable: false,
                    responsive: false,
                    cropBoxResizable: true,
                    minContainerWidth: 300,
                    minContainerHeight: 300,

                });

                croppieInstance.bind({
                    url: e.target.result
                });
            }
            reader.readAsDataURL(file);
        }
    });

    $('#cropButton').on('click', function () {
        const canvas = croppieInstance.getCroppedCanvas({
            width: 113,
            height: 150,
        });

        canvas.toBlob(function (blob) {
            const url = URL.createObjectURL(blob);
            const resizedImageContainer = $('.div-card-photo')[0];
            const resizedImage = $('.img-card-photo')[0];
            resizedImage.src = url;
            resizedImageContainer.style.display = 'block';

            $('#resizeModal').modal('hide');
        }, 'image/jpeg');
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